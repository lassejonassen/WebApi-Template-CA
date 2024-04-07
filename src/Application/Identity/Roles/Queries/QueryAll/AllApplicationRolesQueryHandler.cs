using Application.Common.Interfaces;
using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Roles.Queries.QueryAll;
public class AllApplicationRolesQueryHandler(IApplicationRolesRepository repo)
	: IRequestHandler<AllApplicationRolesQuery, ErrorOr<List<ApplicationRoleResponse>>>
{
	public async Task<ErrorOr<List<ApplicationRoleResponse>>> Handle(AllApplicationRolesQuery query, CancellationToken cancellationToken)
	{
		var applicationRoles = await repo.GetAllAsync(cancellationToken);

		List<ApplicationRoleResponse> applicationRoleResponses
			= applicationRoles
			.Select(role => new ApplicationRoleResponse
			{
				Id = Guid.Parse(role.Id),
				Name = role.Name,
				Description = role.Description,
				CreateTime = role.CreateTime,
				UpdateTime = role.UpdateTime
			})
			.ToList();

		return applicationRoleResponses;
	}
}
