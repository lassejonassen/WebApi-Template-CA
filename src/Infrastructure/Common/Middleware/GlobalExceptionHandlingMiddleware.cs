using Microsoft.AspNetCore.Http;

namespace Infrastructure.Common.Middleware;
public class GlobalExceptionHandlingMiddleware(RequestDelegate next)
{
	private readonly RequestDelegate _next = next;

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (ArgumentNullException ex)
		{
			await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError, "Argument Null Exception");
		}
		catch (InvalidOperationException ex)
		{
			await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError, "Invalid Operation Exception");
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError, "Unhandled Exception");
		}
	}

	private static async Task HandleExceptionAsync(HttpContext context, Exception ex, int statusCode, string errorType)
	{
		context.Response.StatusCode = statusCode;
		context.Response.ContentType = "plain/text";
		await context.Response.WriteAsync($"{errorType}: {ex.Message}");
	}
}
