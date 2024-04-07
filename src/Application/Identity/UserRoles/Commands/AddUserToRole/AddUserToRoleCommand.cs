using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.UserRoles.Commands.AddUserToRole;
public record AddUserToRoleCommand(ApplicationUserRolesRequest Request) : IRequest<ErrorOr<bool>>
{
}
