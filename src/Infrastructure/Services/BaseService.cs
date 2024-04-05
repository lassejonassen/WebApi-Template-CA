using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Common.Interfaces;

namespace Infrastructure.Services;
public class BaseService : IBaseService
{
	private readonly JsonSerializerOptions _options;

	public BaseService()
	{
		_options = new JsonSerializerOptions()
		{
			PropertyNameCaseInsensitive = true,
		};
		_options.Converters.Add(new JsonStringEnumConverter());
	}

	public T Deserialize<T>(string content)
	{
		return JsonSerializer.Deserialize<T>(content, _options);
	}

	public Task<string> GetContent(HttpResponseMessage response) => response.Content.ReadAsStringAsync();

	public string GetUri(string baseUrl, string path)
	{
		StringBuilder sb = new();
		sb.Append(baseUrl?.TrimEnd('/') ?? "").Append(path);
		return sb.ToString();
	}

	public StringContent Serialize(object toSerialize)
	{
		string data = JsonSerializer.Serialize(toSerialize, _options);
		return new StringContent(data, Encoding.UTF8, "application/json");
	}
}
