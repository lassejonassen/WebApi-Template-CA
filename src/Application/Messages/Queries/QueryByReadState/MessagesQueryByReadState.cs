using Contracts.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Queries;

public record MessagesQueryByReadState(bool Read) : IRequest<ErrorOr<List<MessageResponse>>> { }
