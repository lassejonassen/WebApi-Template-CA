using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Identity.Roles.Commands.Create;
using Application.Identity.Roles.Commands.Delete;
using Application.Identity.Roles.Commands.Update;
using Application.Identity.Roles.Queries.QueryAll;
using Application.Identity.Roles.Queries.QueryById;
using Contracts.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/identity/roles")]
[ApiController]
public class RolesController(IMediator _mediator) : ControllerBase
{
	[ProducesResponseType(typeof(ApplicationRoleResponse), StatusCodes.Status200OK)]
	[HttpPost]
	public async Task<IActionResult> Create(CreateApplicationRoleRequest request)
	{
		var message = await _mediator.Send(new CreateApplicationRoleCommand(request));
		return Ok(message);
	}

	[ProducesResponseType(typeof(List<ApplicationRoleResponse>), StatusCodes.Status200OK)]
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var message = await _mediator.Send(new AllApplicationRolesQuery());
		return Ok(message);
	}

	[ProducesResponseType(typeof(ApplicationRoleResponse), StatusCodes.Status200OK)]
	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var result = await _mediator.Send(new ApplicationRoleQueryById(id));
		return Ok(result);
	}

	[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
	[HttpPatch]
	public async Task<IActionResult> Update(UpdateApplicationRoleRequest request)
	{
		var result = await _mediator.Send(new UpdateApplicationRoleCommand(request));
		return Ok(result);
	}


	[ProducesResponseType(typeof(ApplicationRoleResponse), StatusCodes.Status200OK)]
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var result = await _mediator.Send(new DeleteApplicationRoleCommand(id));
		return Ok(result);
	}
}
