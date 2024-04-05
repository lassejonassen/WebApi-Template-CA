using Application.Common.Interfaces;
using Contracts.Github;
using ErrorOr;
using MediatR;

namespace Application.Github.Queries;

public class UserProfileQueryHandler(IGithubService _service) : IRequestHandler<UserProfileQuery, ErrorOr<UserProfileResponse>>
{
	public async Task<ErrorOr<UserProfileResponse>> Handle(UserProfileQuery query, CancellationToken cancellationToken)
	{
		var userProfile = await _service.GetUserProfile();

		return new();
	}
}
