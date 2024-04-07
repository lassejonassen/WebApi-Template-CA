using System.Text.Json;
using Application.Common.Interfaces;
using Domain.Audit;
using Domain.Messages.Events;
using MediatR;

namespace Application.Messages.Events;
public class MessageUpdatedEventHandler(IAuditLogsRepository repository) : INotificationHandler<MessageUpdatedEvent>
{
	public async Task Handle(MessageUpdatedEvent notification, CancellationToken cancellationToken)
	{
		var auditLog = new AuditLog()
		{
			Id = Guid.NewGuid(),
			CreateTime = DateTimeOffset.Now,
			CorrelationId = Guid.NewGuid(),
			EntityType = "Message",
			EntityId = notification.Message.Id.ToString(),
			ChangedByCommand = "UpdateMessageCommand",
			CommandId = Guid.NewGuid().ToString(),
			Content = JsonSerializer.Serialize(notification.Message)
		};

		await repository.CreateAuditLog(auditLog);
	}
}
