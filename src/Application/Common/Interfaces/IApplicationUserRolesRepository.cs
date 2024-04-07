using Domain.Identity;

namespace Application.Common.Interfaces;

public interface IApplicationUserRolesRepository
{
	Task AddUserToRole(ApplicationUser user, string roleName);
	Task RemoveUserFromRole(ApplicationUser user, string roleName);
	Task RemoveAllUsersFromRole(ApplicationRole role);
}
