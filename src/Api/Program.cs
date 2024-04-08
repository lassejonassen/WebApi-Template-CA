using System;
using System.IO;
using Api;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);


		var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

		var configBuilder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("Configuration/appsettings.json", optional: false, reloadOnChange: true)
			.AddJsonFile($"Configuration/appsettings.{environment}.json", optional: true, reloadOnChange: true)
			.AddUserSecrets<IAssemblyMarker>()
			.AddEnvironmentVariables();

		var configuration = configBuilder.Build();
		builder.Configuration.AddConfiguration(configuration);

		builder.Host.UseSerilog((context, configuration) =>
		configuration.ReadFrom.Configuration(context.Configuration));


		builder.Services
				.AddPresentation()
				.AddApplication()
				.AddInfrastructure(builder.Configuration);



		var app = builder.Build();
		{

			app.UseExceptionHandler();
			app.UseInfrastructure();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseSerilogRequestLogging();

			app.UseHttpsRedirection();
			app.MapHealthChecks("api/health");
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}