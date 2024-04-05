using Application.Common.Interfaces;
using Contracts.Identity;
using Domain.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Roles.Commands.Create;
public class CreateApplicationRoleCommandHandler(IApplicationRolesRepository repository)
	: IRequestHandler<CreateApplicationRoleCommand, ErrorOr<ApplicationRoleResponse>>
{
	public async Task<ErrorOr<ApplicationRoleResponse>> Handle(CreateApplicationRoleCommand command, CancellationToken cancellationToken)
	{

		ApplicationRole role = new()
		{
			Id = Guid.NewGuid().ToString(),
			Name = command.Request.Name,
			Description = command.Request.Description,
			CreateTime = DateTimeOffset.Now
		};

		await repository.AddAsync(role, cancellationToken);


		role = await repository.GetByIdAsync(role.Id, cancellationToken);


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
