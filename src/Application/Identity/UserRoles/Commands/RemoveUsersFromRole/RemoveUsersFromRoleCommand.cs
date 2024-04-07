using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;

namespace Application.Identity.UserRoles.Commands.RemoveUsersFromRole;
public record RemoveUsersFromRoleCommand(Guid RoleId)
	: IRequest<ErrorOr<bool>>
{
}
