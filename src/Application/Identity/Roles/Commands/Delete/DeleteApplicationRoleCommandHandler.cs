using Application.Common.Interfaces;
using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Roles.Commands.Delete;
public class DeleteApplicationRoleCommandHandler(IApplicationRolesRepository repo)
	: IRequestHandler<DeleteApplicationRoleCommand, ErrorOr<ApplicationRoleResponse>>
{
	public async Task<ErrorOr<ApplicationRoleResponse>> Handle(DeleteApplicationRoleCommand command, CancellationToken cancellationToken)
	{
		// Checking that the role exists
		var role = await repo.GetByIdAsync(command.Id.ToString(), cancellationToken);
			

		if (role is null)
		{
			return Error.NotFound("ApplicationRole.NotFound", "No ApplicationRole found on that ID");
		}

		await repo.DeleteAsync(role, cancellationToken);

		return new ApplicationRoleResponse
		{
			Id = Guid.Parse(role.Id),
			Name = role.Name,
			Description = role.Description,
			CreateTime = role.CreateTime,
			UpdateTime = role.UpdateTime
		};
	}
}
