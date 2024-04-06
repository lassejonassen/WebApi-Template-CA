using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Roles.Commands.Create;
public record CreateApplicationRoleCommand(CreateApplicationRoleRequest Request) : IRequest<ErrorOr<bool>>
{
}
