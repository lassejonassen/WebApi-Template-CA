using Application.Common.Interfaces;
using Contracts.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Queries;

public class AllMessagesQueryHandler(IMessagesRepository _repository)
	: IRequestHandler<AllMessagesQuery, ErrorOr<List<MessageResponse>>>
{
	public async Task<ErrorOr<List<MessageResponse>>> Handle(AllMessagesQuery query, CancellationToken cancellationToken)
	{
		var messages = await _repository.GetMessagesAsync(cancellationToken);

		if (messages.Count == 0)
		{
			return new List<MessageResponse>();
		}

		List<MessageResponse> messageResponses = messages.Select(message =>
			new MessageResponse(
				message.Id,
				message.To,
				message.From,
				message.Text,
				message.Read))
			.ToList();

		return messageResponses;
	}
}
