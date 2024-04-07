using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Identity.UserRoles.Commands.RemoveUsersFromRole;
public class RemoveUsersFromRoleCommandHandler(IApplicationUserRolesRepository repo, IApplicationRolesRepository rolesRepo)
	: IRequestHandler<RemoveUsersFromRoleCommand, ErrorOr<bool>>
{
	public async Task<ErrorOr<bool>> Handle(RemoveUsersFromRoleCommand command, CancellationToken cancellationToken)
	{
		var role = await rolesRepo.GetByIdAsync(command.RoleId.ToString(), cancellationToken);

		if (role is null)
		{
			return Error.NotFound("ApplicationRole.NotFound", "No Role was found with that ID");
		}

		await repo.RemoveAllUsersFromRole(role);

		return true;
	}
}
