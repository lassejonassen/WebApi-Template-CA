using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Messages.Commands;
using Application.Messages.Queries;
using Asp.Versioning;
using Contracts.Messages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/v{v:apiVersion}/messages")]
[ApiVersion(1)]
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

	[ProducesResponseType(typeof(List<MessageResponse>), StatusCodes.Status200OK)]
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var messages = await _mediator.Send(new AllMessagesQuery());
		return Ok(messages);
	}

	[ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var message = await _mediator.Send(new MessageQueryById(id));
		return Ok(message);
	}

	[ProducesResponseType(typeof(List<MessageResponse>), StatusCodes.Status200OK)]
	[HttpGet("read-state/{read}")]
	public async Task<IActionResult> GetByReadState(bool read)
	{
		var messages= await _mediator.Send(new MessagesQueryByReadState(read));
		return Ok(messages);
	}

	[ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
	[HttpPatch]
	public async Task<IActionResult> Update(UpdateMessageRequest request)
	{
		var message = await _mediator.Send(new UpdateMessageCommand(request));
		return Ok(message);
	}

	[ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var message = await _mediator.Send(new DeleteMessageCommand(id));
		return Ok(message);
	}
}
