﻿using System.Security.Claims;
using Domain.Identity;

namespace Application.Common.Interfaces;

public interface IApplicationRolesRepository
{
	Task AddAsync(ApplicationRole role, CancellationToken cancellationToken);
	Task<List<ApplicationRole>> GetAllAsync(CancellationToken cancellationToken);
	Task<ApplicationRole> GetByIdAsync(string id, CancellationToken cancellationToken);
	Task UpdateAsync(ApplicationRole role, CancellationToken cancellationToken);
	Task DeleteAsync(ApplicationRole role, CancellationToken cancellationToken);

	Task AddClaim(ApplicationRole role, Claim claim);
	Task<List<Claim>> GetClaims(ApplicationRole role);
	Task RemoveClaim(ApplicationRole role, Claim claim);
}
