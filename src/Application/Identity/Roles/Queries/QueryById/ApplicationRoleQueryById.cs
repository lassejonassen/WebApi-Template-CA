using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Roles.Queries.QueryById;
public record ApplicationRoleQueryById(Guid Id) : IRequest<ErrorOr<ApplicationRoleResponse>>
{
}
