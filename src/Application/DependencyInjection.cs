using Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(options =>
		{
			options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
			//options.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
			//options.AddOpenBehavior(typeof(ValidationBehavior<,>));
			options.AddOpenBehavior(typeof(LoggingBehavior<,>));
		});

		services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));
		return services;
	}
}