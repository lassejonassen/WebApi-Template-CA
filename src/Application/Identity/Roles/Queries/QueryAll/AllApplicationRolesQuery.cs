using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Roles.Queries.QueryAll;
public record AllApplicationRolesQuery :IRequest<ErrorOr<List<ApplicationRoleResponse>>> { }
