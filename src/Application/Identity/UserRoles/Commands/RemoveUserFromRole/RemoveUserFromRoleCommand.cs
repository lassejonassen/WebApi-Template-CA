using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.UserRoles.Commands.RemoveUserFromRole;
public record RemoveUserFromRoleCommand(ApplicationUserRolesRequest Request)
	: IRequest<ErrorOr<bool>>
{
}
