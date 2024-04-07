using Application.Common.Interfaces;
using Domain.Identity;
using Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity.Persistence;
public class ApplicationUserRolesRepository(AppDbContext _dbContext, UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager) 
	: IApplicationUserRolesRepository
{
	public async Task AddUserToRole(ApplicationUser user, string roleName)
	{
		await _userManager.AddToRoleAsync(user, roleName);
	}

	public async Task RemoveAllUsersFromRole(ApplicationRole role)
	{
		var usersInRole = await _dbContext.UserRoles
			.Where(user => user.RoleId == role.Id)
			.ToListAsync();

		foreach (var userRole in usersInRole)
		{
			var user = await _userManager.FindByIdAsync(userRole.UserId);
			if (user is not null)
			{
				await _userManager.RemoveFromRoleAsync(user, role.Name);
			}
		}
	}

	public async Task RemoveUserFromRole(ApplicationUser user, string roleName)
	{
		await _userManager.RemoveFromRoleAsync(user, roleName);
	}
}
