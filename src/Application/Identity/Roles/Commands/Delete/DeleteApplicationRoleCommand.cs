using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Roles.Commands.Delete;

public record DeleteApplicationRoleCommand(Guid Id) : IRequest<ErrorOr<ApplicationRoleResponse>>
{
}
