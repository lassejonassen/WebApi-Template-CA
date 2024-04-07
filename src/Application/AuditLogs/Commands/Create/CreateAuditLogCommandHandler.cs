using Application.Common.Interfaces;
using Domain.Audit;
using ErrorOr;
using MediatR;

namespace Application.AuditLogs.Commands.Create;
public class CreateAuditLogCommandHandler(IAuditLogsRepository repo)
	: IRequestHandler<CreateAuditLogCommand, ErrorOr<AuditLog>>
{
	public async Task<ErrorOr<AuditLog>> Handle(CreateAuditLogCommand command, CancellationToken cancellationToken)
	{
		var auditLog = new AuditLog()
		{
			Id = Guid.NewGuid(),
			CreateTime = DateTimeOffset.Now,
			CorrelationId = Guid.NewGuid(),
			EntityType = command.Request.EntityType,
			EntityId = command.Request.EntityId,
			ChangedByCommand = command.Request.ChangedByCommand,
			CommandId = command.Request.CommandId,
			ChangedByUser = command.Request.ChangedByUser,
			Content = command.Request.Content
		};

		await repo.CreateAuditLog(auditLog);

		return auditLog;
	}
}
