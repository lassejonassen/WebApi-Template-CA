using Application.Common.Interfaces;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity.Persistence;

public class ApplicationRolesRepository(RoleManager<ApplicationRole> roleManager) : IApplicationRolesRepository
{
	private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

	public async Task AddAsync(ApplicationRole role, CancellationToken cancellationToken)
	{
		await _roleManager.CreateAsync(role);
	}

	public async Task DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
	{
		await _roleManager.DeleteAsync(role);
	}

	public async Task<List<ApplicationRole>> GetAllAsync(CancellationToken cancellationToken)
	{
		return await _roleManager.Roles.ToListAsync();
	}

	public async Task<ApplicationRole> GetByIdAsync(string id, CancellationToken cancellationToken)
	{
		return await _roleManager.FindByIdAsync(id);
	}

	public async Task UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
	{
		await _roleManager.UpdateAsync(role);
	}
}
