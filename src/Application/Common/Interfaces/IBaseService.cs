namespace Application.Common.Interfaces;

public interface IBaseService
{
	T Deserialize<T>(string content);
	StringContent Serialize(object toSerialize);
	string GetUri(string baseUrl, string path);
	Task<string> GetContent(HttpResponseMessage response);
}
