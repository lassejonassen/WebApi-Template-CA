using Contracts.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Commands.Create;

public record CreateMessageCommand(CreateMessageRequest Request)
: IRequest<ErrorOr<MessageResponse>>
{ }
