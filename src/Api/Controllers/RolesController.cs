using System.Threading.Tasks;
using Application.Identity.Roles.Commands.Create;
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
}
