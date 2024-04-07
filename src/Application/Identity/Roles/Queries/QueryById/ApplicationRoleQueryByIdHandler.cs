using Application.Common.Interfaces;
using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Roles.Queries.QueryById;
public class ApplicationRoleQueryByIdHandler(IApplicationRolesRepository repo)
	: IRequestHandler<ApplicationRoleQueryById, ErrorOr<ApplicationRoleResponse>>
{
	public async Task<ErrorOr<ApplicationRoleResponse>> Handle(ApplicationRoleQueryById query, CancellationToken cancellationToken)
	{
		var applicationRole = await repo.GetByIdAsync(query.Id.ToString(), cancellationToken);

		if (applicationRole is null)
		{
			return Error.NotFound("ApplicationRole.NotFound", "No ApplicationRole found on that ID");
		}

		return new ApplicationRoleResponse
		{
			Id = Guid.Parse(applicationRole.Id),
			Name = applicationRole.Name,
			Description = applicationRole.Description,
			CreateTime = applicationRole.CreateTime,
			UpdateTime = applicationRole.UpdateTime
		};
	}
}
