using Application.Common.Interfaces;
using Contracts.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Commands;

public class DeleteMessageCommandHandler(IMessagesRepository _repository) 
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

		return new MessageResponse(message.Id, message.To, message.From, message.Text, message.Read);
	}	
}
