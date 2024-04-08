using Application.Common.Interfaces;
using Contracts.Messages;
using Domain.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Commands;

public class CreateMessageCommandHandler(IMessagesRepository _repository) 
	: IRequestHandler<CreateMessageCommand, ErrorOr<MessageResponse>>
{
	public async Task<ErrorOr<MessageResponse>> Handle(CreateMessageCommand command, CancellationToken cancellationToken)
	{
		var message = new Message(
			id: Guid.NewGuid(), 
			createTime: DateTimeOffset.Now, 
			correlationId: Guid.NewGuid(),
			to: command.Request.To, 
			from: command.Request.From, 
			text: command.Request.Text, 
			read: false);

		// Checking that no other message has the same ID.
		var exists = await _repository.GetMessageByIdAsync(message.Id, cancellationToken);

		if (exists is not null)
		{
			return Error.Conflict(code: "Message.Conflict", description: "Two Messages cannot have the same ID");
		}

		// Adding the message.
		await _repository.AddAsync(message, cancellationToken);


		return new MessageResponse(message.Id, message.To, message.From, message.Text, message.Read);
	}
}
