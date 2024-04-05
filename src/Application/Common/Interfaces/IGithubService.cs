using Domain.Github;

namespace Application.Common.Interfaces;

public interface IGithubService
{
	Task<UserProfile> GetUserProfile();
}
