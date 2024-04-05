using Contracts.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Commands;

public record UpdateMessageCommand(UpdateMessageRequest Request)
	: IRequest<ErrorOr<MessageResponse>>
{ }

