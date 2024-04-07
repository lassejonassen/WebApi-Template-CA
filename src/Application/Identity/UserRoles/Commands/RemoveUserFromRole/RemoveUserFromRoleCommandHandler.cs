using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Identity.UserRoles.Commands.RemoveUserFromRole;
public class RemoveUserFromRoleCommandHandler(IApplicationUserRolesRepository repo, IApplicationUsersRepository usersRepo, IApplicationRolesRepository rolesRepo)
	: IRequestHandler<RemoveUserFromRoleCommand, ErrorOr<bool>>
{
	public async Task<ErrorOr<bool>> Handle(RemoveUserFromRoleCommand command, CancellationToken cancellationToken)
	{
		var user = await usersRepo.GetByIdAsync(command.Request.UserId.ToString(), cancellationToken);

		if (user is null)
		{
			return Error.NotFound("ApplicationUser.NotFound", "No User was found with given ID");
		}

		var role = await rolesRepo.GetByIdAsync(command.Request.RoleId.ToString(), cancellationToken);

		if (role is null)
		{
			return Error.NotFound("ApplicationRole.NotFound", "No role was found with given ID");
		}

		await repo.RemoveUserFromRole(user, role.Name);

		return true;
	}
}
