using Application.Common.Interfaces;
using Contracts.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Commands;

public class UpdateMessageCommandHandler(IMessagesRepository _repository) 
	: IRequestHandler<UpdateMessageCommand, ErrorOr<MessageResponse>>
{
	public async Task<ErrorOr<MessageResponse>> Handle(UpdateMessageCommand command, CancellationToken cancellationToken)
	{
		var message = await _repository.GetMessageByIdAsync(command.Request.Id, cancellationToken);

		if(message is null)
		{
			return Error.NotFound("Message.NotFound", "No Message with the given ID was found");
		}

		message.To = command.Request.To;
		message.From = command.Request.From;
		message.Text = command.Request.Text;
		message.Read = command.Request.Read;

		var updateMessageResult = message.UpdateMessage();

		if (updateMessageResult.IsError)
		{
			return updateMessageResult.Errors;
		}

		await _repository.UpdateAsync(message, cancellationToken);

		return new MessageResponse(message.Id, message.To, message.From, message.Text, message.Read);
	}
}