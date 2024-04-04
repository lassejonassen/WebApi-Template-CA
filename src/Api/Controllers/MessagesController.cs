using System.Threading.Tasks;
using Application.Messages.Commands.Create;
using Contracts.Messages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/messages")]
[ApiController]
public class MessagesController(IMediator _mediator) : ControllerBase
{
	[ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
	[HttpPost]
	public async Task<IActionResult> Create(CreateMessageRequest request)
	{
		var message = await _mediator.Send(new CreateMessageCommand(request));
		return Ok(message);
	}
}
