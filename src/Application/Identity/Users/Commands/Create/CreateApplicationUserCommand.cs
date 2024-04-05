using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Users.Commands.Create;
public record CreateApplicationUserCommand(CreateApplicationUserRequest Request) : IRequest<ErrorOr<ApplicationUserResponse>>
{
}
