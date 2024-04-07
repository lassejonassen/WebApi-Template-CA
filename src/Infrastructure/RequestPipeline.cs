using Infrastructure.Common.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure;

public static class RequestPipeline
{
	public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
	{
		app.UseMiddleware<EventualConsistencyMiddleware>();
		app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
		//DataSeeding.SeedDefaultUser(app);
		return app;
	}
}
