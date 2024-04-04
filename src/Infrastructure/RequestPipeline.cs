using Infrastructure.Common.Middleware;
using Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure;

public static class RequestPipeline
{
	public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
	{
		app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
		app.UseMiddleware<EventualConsistencyMiddleware>();
		DataSeeding.SeedDefaultUser(app);
		return app;
	}
}
