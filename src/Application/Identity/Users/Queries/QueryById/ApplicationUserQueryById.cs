using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Users.Queries.QueryById;
public record ApplicationUserQueryById(Guid Id) : IRequest<ErrorOr<ApplicationUserResponse>>
{
}
