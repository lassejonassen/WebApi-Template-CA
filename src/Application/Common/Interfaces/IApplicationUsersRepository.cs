using System.Security.Claims;
using Domain.Identity;

namespace Application.Common.Interfaces;

public interface IApplicationUsersRepository
{
	Task AddAsync(ApplicationUser user, string password, CancellationToken cancellationToken);
	Task<List<ApplicationUser>> GetAllAsync(CancellationToken cancellationToken);
	Task<ApplicationUser> GetByIdAsync(string id, CancellationToken cancellationToken);
	Task<ApplicationUser> GetByEmailAsync(string email, CancellationToken cancellationToken);
	Task<ApplicationUser> GetByUsername(string userName, CancellationToken cancellationToken);
	Task UpdateAsync(ApplicationUser user, CancellationToken cancellationToken);
	Task DeleteAsync(ApplicationUser user, CancellationToken cancellationToken);

	Task<bool> CheckPassword(ApplicationUser user, string password);
	Task<List<string>> GetUsersRoles(ApplicationUser user);

	Task AddClaim(ApplicationUser user, Claim claim);
	Task AddClaims(ApplicationUser user, List<Claim> claims);
	Task<List<Claim>> GetClaims(ApplicationUser user);
	Task RemoveClaim(ApplicationUser user, Claim claim);
	Task RemoveClaims(ApplicationUser user, List<Claim> claims);
}
