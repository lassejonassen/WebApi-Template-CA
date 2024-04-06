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

	public async Task DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
	{
		await _userManager.DeleteAsync(user);
	}

	public async Task<List<ApplicationUser>> GetAllAsync(CancellationToken cancellationToken)
	{
		return await _userManager.Users.ToListAsync(cancellationToken);
	}

	public async Task<ApplicationUser> GetByIdAsync(string id, CancellationToken cancellationToken)
	{
		return await _userManager.FindByIdAsync(id);
	}

	public async Task UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
	{
		await _userManager.UpdateAsync(user);
	}
}
