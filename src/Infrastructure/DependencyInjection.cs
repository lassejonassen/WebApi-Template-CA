using Application.Common.Interfaces;
using Domain.Identity;
using Infrastructure.Common.Persistence;
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

namespace Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services
		   .AddHttpContextAccessor()
		   .AddServices()
		   .AddBackgroundServices()
		   .AddAuthentication(configuration)
		   .AddAuthorization()
		   .AddIdentity()
		   .AddPersistence();

		return services;
	}

	private static IServiceCollection AddBackgroundServices(this IServiceCollection services)
	{
		//services.AddEmailNotifications(configuration);
		return services;
	}


	private static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

		return services;
	}

	private static IServiceCollection AddPersistence(this IServiceCollection services)
	{
		services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source = database.sqlite"));

		services.AddScoped<IRemindersRepository, RemindersRepository>();
		services.AddScoped<IUsersRepository, UsersRepository>();

		return services;
	}

	private static IServiceCollection AddAuthorization(this IServiceCollection services)
	{
		services.AddScoped<IAuthorizationService, AuthorizationService>();
		services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
		services.AddSingleton<IPolicyEnforcer, PolicyEnforcer>();

		return services;
	}

	private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));

		services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

		services
			.ConfigureOptions<JwtBearerTokenValidationConfiguration>()
			.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer();

		return services;
	}

	private static IServiceCollection AddIdentity(this IServiceCollection services)
	{
		services.AddIdentityCore<ApplicationUser>()
			.AddRoles<IdentityRole>()
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
}