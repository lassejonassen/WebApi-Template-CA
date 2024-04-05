using Contracts.Messages;
using ErrorOr;
using MediatR;

namespace Application.Messages.Queries;

public record MessageQueryById(Guid Id) : IRequest<ErrorOr<MessageResponse>> { }
