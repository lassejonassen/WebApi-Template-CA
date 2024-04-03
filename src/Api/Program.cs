using Api;
using Application;
using Infrastructure;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		{
			builder.Services
				.AddPresentation()
				.AddApplication()
				.AddInfrastructure(builder.Configuration)
				.AddEndpointsApiExplorer()
				.AddSwaggerGen();
		}

		var app = builder.Build();
		{
			app.UseExceptionHandler();
			app.UseInfrastructure();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}