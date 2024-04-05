using Application.Common.Interfaces;
using Contracts.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Queries;
public class MessageQueryByIdHandler(IMessagesRepository _repository)
	: IRequestHandler<MessageQueryById, ErrorOr<MessageResponse>>
{
	public async Task<ErrorOr<MessageResponse>> Handle(MessageQueryById query, CancellationToken cancellationToken)
	{
		var message = await _repository.GetMessageByIdAsync(query.Id, cancellationToken);

		if (message is null)
		{
			return Error.NotFound("Message.NotFound", "No message found with that ID");
		}

		return new MessageResponse(
				message.Id,
				message.To,
				message.From,
				message.Text,
				message.Read);
	}
}
