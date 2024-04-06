using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Identity.Users.Commands.Create;
using Application.Identity.Users.Commands.Delete;
using Application.Identity.Users.Commands.Update;
using Application.Identity.Users.Queries.QueryAll;
using Application.Identity.Users.Queries.QueryById;
using Contracts.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/identity/users")]
[ApiController]
public class UsersController(IMediator _mediator) : ControllerBase
{
	[ProducesResponseType(typeof(ApplicationUserResponse), StatusCodes.Status200OK)]
	[HttpPost]
	public async Task<IActionResult> Create(CreateApplicationUserRequest request)
	{
		var message = await _mediator.Send(new CreateApplicationUserCommand(request));
		return Ok(message);
	}

	[ProducesResponseType(typeof(List<ApplicationUserResponse>), StatusCodes.Status200OK)]
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var message = await _mediator.Send(new AllApplicationUsersQuery());
		return Ok(message);
	}

	[ProducesResponseType(typeof(ApplicationUserResponse), StatusCodes.Status200OK)]
	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var result = await _mediator.Send(new ApplicationUserQueryById(id));
		return Ok(result);
	}

	[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
	[HttpPatch]
	public async Task<IActionResult> Update(UpdateApplicationUserRequest request)
	{
		var result = await _mediator.Send(new UpdateApplicationUserCommand(request));
		return Ok(result);
	}


	[ProducesResponseType(typeof(ApplicationUserResponse), StatusCodes.Status200OK)]
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var result = await _mediator.Send(new DeleteApplicationUserCommand(id));
		return Ok(result);
	}
}
