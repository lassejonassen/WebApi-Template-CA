using Contracts.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Commands;
public record DeleteMessageCommand(Guid Id) : IRequest<ErrorOr<MessageResponse>>
{ }
