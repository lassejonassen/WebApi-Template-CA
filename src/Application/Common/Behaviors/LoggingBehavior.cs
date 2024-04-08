using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviors;
public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
	: IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
	where TResponse : IErrorOr
{

	private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger = logger;
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		_logger.LogInformation("Starting request {@RequestName}, {@DateTime}", 
			typeof(TRequest).Name, 
			DateTime.Now);

		var result = await next();

		if (result.IsError)
		{
			_logger.LogError("Request failed {@RequestName}, {@Error} {@DateTime}",
			typeof(TRequest).Name,
			result.Errors,
			DateTime.Now);
		}

		_logger.LogInformation("Completed request {@RequestName}, {@DateTime}",
			typeof(TRequest).Name,
			DateTime.Now);
		return result;
	}
}
