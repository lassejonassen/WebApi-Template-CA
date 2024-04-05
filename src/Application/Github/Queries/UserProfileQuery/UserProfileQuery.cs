using Contracts.Github;
using ErrorOr;
using MediatR;

namespace Application.Github.Queries;

public record UserProfileQuery : IRequest<ErrorOr<UserProfileResponse>> { }