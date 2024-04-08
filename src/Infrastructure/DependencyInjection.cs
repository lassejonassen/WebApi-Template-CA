using System.Net.Http.Headers;
using Application.Common.Interfaces;
using Asp.Versioning;
using Domain.Identity;
using Infrastructure.AuditLogs.Persistence;
using Infrastructure.Common.Persistence;
using Infrastructure.Github;
using Infrastructure.HealthChecks;
using Infrastructure.Identity.Persistence;
using Infrastructure.Messages.Persistence;
using Infrastructure.Reminders.Persistence;
using Infrastructure.Security;
using Infrastructure.Security.CurrentUserProvider;
using Infrastructure.Security.PolicyEnforcer;
using Infrastructure.Security.TokenGenerator;
using Infrastructure.Security.TokenValidation;
using Infrastructure.Services;
using Infrastructure.Users.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services
			.AddHttpContextAccessor()
			.AddOptionsPattern(configuration)
			.AddPersistence(configuration)
			.AddServices()
			.AddHttpClient(configuration)
			.AddBackgroundServices()
			.AddCustomHealthChecks()
			.AddAuthentication(configuration)
			.AddAuthorization()
			.AddApiVersioning()
			.AddIdentity();

		return services;
	}

	private static IServiceCollection AddApiVersioning(this IServiceCollection services)
	{
		services.AddApiVersioning(options =>
		{
			options.DefaultApiVersion = new ApiVersion(1);
			options.ReportApiVersions = true;
			options.AssumeDefaultVersionWhenUnspecified = true;
			options.ApiVersionReader = ApiVersionReader.Combine(
				new UrlSegmentApiVersionReader(),
				new HeaderApiVersionReader("X-Api-Version"));
		}).AddApiExplorer(options =>
		{
			options.GroupNameFormat = "'v'V";
			options.SubstituteApiVersionInUrl = true;
		});

		return services;
	}

	private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
	{
		services
			.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>()
			.ConfigureOptions<JwtBearerTokenValidationConfiguration>()
			.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer();

		return services;
	}

	private static IServiceCollection AddAuthorization(this IServiceCollection services)
	{
		services.AddScoped<IAuthorizationService, AuthorizationService>();
		services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
		services.AddSingleton<IPolicyEnforcer, PolicyEnforcer>();

		return services;
	}

	private static IServiceCollection AddBackgroundServices(this IServiceCollection services)
	{
		//services.AddEmailNotifications(configuration);
		return services;
	}

	private static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
	{
		services.AddHealthChecks()
			.AddCheck<DatabaseHealthCheck>("custom-sql", HealthStatus.Unhealthy)
			.AddDbContextCheck<AppDbContext>();
		return services;
	}

	private static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddHttpClient<IGithubService, GithubService>((httpClient) =>
		{
			var githubSettings = configuration.GetSection(GithubSettings.Section).Get<GithubSettings>();

			httpClient.BaseAddress = new Uri(githubSettings.BasePath);
			httpClient.Timeout = TimeSpan.FromSeconds(5);
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", githubSettings.PAT);
		});

		return services;
	}

	private static IServiceCollection AddIdentity(this IServiceCollection services)
	{
		services
			.AddIdentityCore<ApplicationUser>()
			.AddRoles<ApplicationRole>()
			.AddEntityFrameworkStores<AppDbContext>();
		services.Configure<IdentityOptions>(options =>
		{
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequiredLength = 8;
			options.Password.RequireUppercase = true;
			options.Password.RequireLowercase = true;
			options.Password.RequireDigit = true;
			options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
			options.User.RequireUniqueEmail = true;
		});

		return services;
	}

	private static IServiceCollection AddOptionsPattern(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<DatabaseSettings>(configuration.GetSection(DatabaseSettings.Section));
		services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));
		services.Configure<GithubSettings>(configuration.GetSection(GithubSettings.Section));
		return services;
	}

	private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		// Retrieve the DatabaseSettings from the configuration
		var databaseSettings = configuration.GetSection(DatabaseSettings.Section).Get<DatabaseSettings>();

		// Use the connection string from the DatabaseSettings
		services.AddDbContext<AppDbContext>(options => options.UseSqlServer(databaseSettings.ConnectionString));

		services.AddScoped<IMessagesRepository, MessagesRepository>();
		services.AddScoped<IRemindersRepository, RemindersRepository>();
		services.AddScoped<IUsersRepository, UsersRepository>();
		services.AddScoped<IApplicationUsersRepository, ApplicationUsersRepository>();
		services.AddScoped<IApplicationRolesRepository, ApplicationRolesRepository>();
		services.AddScoped<IApplicationUserRolesRepository, ApplicationUserRolesRepository>();
		services.AddScoped<IAuditLogsRepository, AuditLogsRepository>();

		return services;
	}

	private static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
		return services;
	}
}