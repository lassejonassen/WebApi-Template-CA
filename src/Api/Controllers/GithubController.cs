using System.Threading.Tasks;
using Application.Github.Queries;
using Contracts.Github;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/github")]
[ApiController]
public class GithubController(IMediator _mediator) : ControllerBase
{
	[ProducesResponseType(typeof(UserProfileResponse), StatusCodes.Status200OK)]
	[HttpGet("get-user-profile")]
	public async Task<IActionResult> GetUserProfile()
	{
		var userProfile = await _mediator.Send(new UserProfileQuery());
		return Ok(userProfile);
	}
}
