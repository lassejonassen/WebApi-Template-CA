using ErrorOr;
using MediatR;

namespace Application.Identity.Users.Commands.Delete;
public record DeleteApplicationUserCommand(Guid Id) : IRequest<ErrorOr<bool>>
{
}
