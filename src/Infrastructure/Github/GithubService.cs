using Application.Common.Interfaces;
using Domain.Github;
using Infrastructure.Services;
using Microsoft.Extensions.Options;

namespace Infrastructure.Github;

public class GithubService(HttpClient httpClient, IOptions<GithubSettings> options) : BaseService, IGithubService
{
	private readonly HttpClient _httpClient = httpClient;
	private readonly GithubSettings _options = options.Value;

	private async Task<T> GetApiResponse<T>(string path, HttpMethod method, HttpContent content = null)
	{
		var request = new HttpRequestMessage
		{
			Method = method,
			RequestUri = new Uri(GetUri(_httpClient.BaseAddress.ToString(), path)),
			Content = content
		};

		var response = await _httpClient.SendAsync(request);
		response.EnsureSuccessStatusCode();

		string responseContent = await GetContent(response);
		return Deserialize<T>(responseContent);
	}

	public async Task<UserProfile> GetUserProfile()
	{
		string url = $"/users/{_options.Username}";
		return await GetApiResponse<UserProfile>(url, HttpMethod.Get);
	}
}
