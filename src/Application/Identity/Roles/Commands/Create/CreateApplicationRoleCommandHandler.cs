using Application.Common.Interfaces;
using Domain.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Roles.Commands.Create;
public class CreateApplicationRoleCommandHandler(IApplicationRolesRepository repository)
	: IRequestHandler<CreateApplicationRoleCommand, ErrorOr<bool>>
{
	public async Task<ErrorOr<bool>> Handle(CreateApplicationRoleCommand command, CancellationToken cancellationToken)
	{

		ApplicationRole role = new()
		{
			Id = Guid.NewGuid().ToString(),
			Name = command.Request.Name,
			Description = command.Request.Description,
			CreateTime = DateTimeOffset.Now
		};

		await repository.AddAsync(role, cancellationToken);


		await repository.GetByIdAsync(role.Id, cancellationToken);

		return true;
	}
}
