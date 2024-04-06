using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Users.Commands.Update;
public record UpdateApplicationUserCommand(UpdateApplicationUserRequest Request) : IRequest<ErrorOr<bool>>
{
}
