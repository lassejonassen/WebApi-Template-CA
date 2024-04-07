using System.Collections.Generic;
using System.Threading.Tasks;
using Application.AuditLogs.Commands.Create;
using Application.AuditLogs.Queries.QueryByEntityId;
using Contracts.AuditLogs;
using Domain.Audit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/v{v:apiVersion}/auditlogs")]
[ApiController]
public class AuditLogsController(IMediator _mediator) : ControllerBase
{
	[ProducesResponseType(typeof(AuditLog), StatusCodes.Status200OK)]
	[HttpPost]
	public async Task<IActionResult> Create(CreateAuditLogRequest request)
	{
		var auditLog = await _mediator.Send(new CreateAuditLogCommand(request));
		return Ok(auditLog);
	}

	[ProducesResponseType(typeof(List<AuditLog>), StatusCodes.Status200OK)]
	[HttpGet("{entityType}/{entityId}")]
	public async Task<IActionResult> GetOnEntityId(string entityType, string entityId)
	{
		var messages = await _mediator.Send(new AuditLogsOnEntityIdQuery(entityType, entityId));
		return Ok(messages);
	}
}
