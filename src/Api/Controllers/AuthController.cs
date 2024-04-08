using System.Threading.Tasks;
using Application.Auth.Commands.Login;
using Contracts.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator _mediator) : ControllerBase
{
	[ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
	[HttpPost]
	public async Task<IActionResult> Login(LoginRequest request)
	{
		var response = await _mediator.Send(new LoginRequestCommand(request));
		return Ok(response);
	}
}
