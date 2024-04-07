using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Identity.Roles.Commands.Update;
public class UpdateApplicationRoleCommandHandler(IApplicationRolesRepository repo)
	: IRequestHandler<UpdateApplicationRoleCommand, ErrorOr<bool>>
{
	public async Task<ErrorOr<bool>> Handle(UpdateApplicationRoleCommand command, CancellationToken cancellationToken)
	{
		var role = await repo.GetByIdAsync(command.Request.Id.ToString(), cancellationToken);

		if (role is null)
		{
			return Error.NotFound("ApplicationRole.NotFound", "No ApplicationRole found on that ID");
		}


		role.Name = command.Request.Name;
		role.Description = command.Request.Description;
		role.UpdateTime = DateTimeOffset.Now;

		await repo.UpdateAsync(role, cancellationToken);

		return true;
	}
}
