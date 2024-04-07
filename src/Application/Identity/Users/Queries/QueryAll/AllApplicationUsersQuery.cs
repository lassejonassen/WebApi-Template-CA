using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Users.Queries.QueryAll;
public record AllApplicationUsersQuery : IRequest<ErrorOr<List<ApplicationUserResponse>>>
{
}
