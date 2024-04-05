using Domain.Identity;

namespace Application.Common.Interfaces;

public interface IApplicationUsersRepository
{
	Task AddAsync(ApplicationUser user, string password, CancellationToken cancellationToken);
	Task<List<ApplicationUser>> GetAllAsync(CancellationToken cancellationToken);
	Task<ApplicationUser> GetByIdAsync(string id, CancellationToken cancellationToken);
	Task UpdateAsync(ApplicationUser user, CancellationToken cancellationToken);
	Task DeleteAsync(ApplicationUser user, CancellationToken cancellationToken);
}
