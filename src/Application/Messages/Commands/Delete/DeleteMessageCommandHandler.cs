using System.Text.Json;
using Application.Common.Interfaces;
using Contracts.Messages;
using Domain.Audit;
using Domain.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Commands;

public class DeleteMessageCommandHandler(IMessagesRepository _repository, IAuditLogsRepository auditRepo) 
	: IRequestHandler<DeleteMessageCommand, ErrorOr<MessageResponse>>
{
	public async Task<ErrorOr<MessageResponse>> Handle(DeleteMessageCommand command, CancellationToken cancellationToken)
	{
		var message = await _repository.GetMessageByIdAsync(command.Id, cancellationToken);

		if (message is null)
		{
			return Error.NotFound("Message.NotFound", "No message was found on that ID");
		}

		await _repository.RemoveAsync(message, cancellationToken);

		var auditLog = new AuditLog()
		{
			Id = Guid.NewGuid(),
			CreateTime = DateTimeOffset.Now,
			CorrelationId = Guid.NewGuid(),
			EntityType = message.GetType().Name,
			EntityId = message.Id.ToString(),
			ChangedByCommand = GetType().Name,
			CommandId = Guid.NewGuid().ToString(),
			Content = JsonSerializer.Serialize(message)
		};

		await auditRepo.CreateAuditLog(auditLog);

		return new MessageResponse(message.Id, message.To, message.From, message.Text, message.Read);
	}	
}
