using Contracts.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Queries;

public record AllMessagesQuery : IRequest<ErrorOr<List<MessageResponse>>> { }
