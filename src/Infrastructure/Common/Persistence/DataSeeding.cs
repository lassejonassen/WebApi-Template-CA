using Domain.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Persistence;
public class DataSeeding
{
	public static async void SeedDefaultUser(IApplicationBuilder app)
	{
		// Getting the DbContext.
		AppDbContext context = app.ApplicationServices.CreateScope()
			.ServiceProvider.GetRequiredService<AppDbContext>();

		// Checking for any migrations.
		if (context.Database.GetPendingMigrations().Any())
		{
			context.Database.Migrate();
		}

		// Getting a userManager instance.
		UserManager<ApplicationUser> userManager = app.ApplicationServices
			.CreateScope()
			.ServiceProvider
			.GetRequiredService<UserManager<ApplicationUser>>();

		// Checking if there is any users.
		// If no users is found, a default user is created.
		if(!userManager.Users.Any())
		{
			var user = new ApplicationUser()
			{
				FirstName = "Lasse",
				LastName = "Jonassen",
				Email = "lassejonassen@fakemail.com",
				UserName = "lassejonassen@fakemail.com",
				PhoneNumber = "12341234"
			};

			// Creating the user

			var isCreated = await userManager.CreateAsync(user, "Start1234!");

			if (!isCreated.Succeeded)
			{
				throw new Exception("Default User was not created");
			}

			var role = new IdentityRole
			{
				Name = "Admin"
			};

			RoleManager<IdentityRole> roleManager
				= app.ApplicationServices.CreateScope()
				.ServiceProvider
				.GetRequiredService<RoleManager<IdentityRole>>();

			isCreated = await roleManager.CreateAsync(role);

			if (!isCreated.Succeeded)
			{
				throw new Exception("Admin role was not created");
			}

			var user2 = await userManager.FindByEmailAsync(user.Email);

			var isAssigned = await userManager.AddToRoleAsync(user2, "Admin");

			if (!isAssigned.Succeeded)
			{
				throw new Exception("Could not assign defautl user to admin role");
			}
		}
	}
}
