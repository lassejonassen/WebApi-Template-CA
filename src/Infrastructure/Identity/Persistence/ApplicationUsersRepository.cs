using Application.Common.Interfaces;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity.Persistence;

public class ApplicationUsersRepository(UserManager<ApplicationUser> userManager) : IApplicationUsersRepository
{
	private readonly UserManager<ApplicationUser> _userManager = userManager;

	public async Task AddAsync(ApplicationUser user, string password, CancellationToken cancellationToken)
	{
		await _userManager.CreateAsync(user, password);
	}

	public async Task<bool> CheckPassword(ApplicationUser user, string password)
	{
		return await _userManager.CheckPasswordAsync(user, password);
	}

	public async Task DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
	{
		await _userManager.DeleteAsync(user);
	}

	public async Task<List<ApplicationUser>> GetAllAsync(CancellationToken cancellationToken)
	{
		return await _userManager.Users.ToListAsync(cancellationToken);
	}

	public async Task<ApplicationUser> GetByEmailAsync(string email, CancellationToken cancellationToken)
	{
		return await _userManager.FindByEmailAsync(email);
	}

	public async Task<ApplicationUser> GetByIdAsync(string id, CancellationToken cancellationToken)
	{
		return await _userManager.FindByIdAsync(id);
	}

	public async Task<ApplicationUser> GetByUsername(string userName, CancellationToken cancellationToken)
	{
		return await _userManager.FindByNameAsync(userName);
	}

	public async Task<List<string>> GetUsersRoles(ApplicationUser user)
	{
		return (List<string>)await _userManager.GetRolesAsync(user);
	}

	public async Task UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
	{
		await _userManager.UpdateAsync(user);
	}
}
