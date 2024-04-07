using System;
using System.Threading.Tasks;
using Application.Identity.UserRoles.Commands.AddUserToRole;
using Application.Identity.UserRoles.Commands.RemoveUserFromRole;
using Application.Identity.UserRoles.Commands.RemoveUsersFromRole;
using Contracts.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/identity/user-roles")]
[ApiController]
public class UserRolesController(IMediator _mediator) : ControllerBase
{
	[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
	[HttpPost("add")]
	public async Task<IActionResult> AddUserToRole(ApplicationUserRolesRequest request)
	{
		var message = await _mediator.Send(new AddUserToRoleCommand(request));
		return Ok(message);
	}

	[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
	[HttpPost("remove")]
	public async Task<IActionResult> RemoveUserFromRole(ApplicationUserRolesRequest request)
	{
		var message = await _mediator.Send(new RemoveUserFromRoleCommand(request));
		return Ok(message);
	}

	[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
	[HttpPost("remove-all")]
	public async Task<IActionResult> RemoveAllUsersFromRole([FromBody]Guid roleId)
	{
		var message = await _mediator.Send(new RemoveUsersFromRoleCommand(roleId));
		return Ok(message);
	}
}
