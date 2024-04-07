using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Roles.Commands.Update;
public record UpdateApplicationRoleCommand(UpdateApplicationRoleRequest Request) : IRequest<ErrorOr<bool>>
{
}
