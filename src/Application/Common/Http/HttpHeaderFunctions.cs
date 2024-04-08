using Microsoft.AspNetCore.Http;

namespace Application.Common.Http;

public static class HttpHeaderFunctions
{
	public const string CorrelationIdHeaderKey = "x-correlation-id";
	public const string CausationIdHeaderKey = "x-causation-id";

	public static Guid GetCorrelationId(HttpRequest request)
	{
		return GetHeaderValue(CorrelationIdHeaderKey, request, s => !string.IsNullOrWhiteSpace(s) ? Guid.Parse(s) : Guid.NewGuid());
	}

	public static Guid GetCausationId(HttpRequest request)
	{
		return GetHeaderValue(CausationIdHeaderKey, request, s => !string.IsNullOrWhiteSpace(s) ? Guid.Parse(s) : Guid.Empty);
	}

	public static string GetHeaderValue(string key, HttpRequest request)
	{
		return GetHeaderValue(key, request, s => !string.IsNullOrWhiteSpace(s) ? s : "");
	}

	private static T GetHeaderValue<T>(string key, HttpRequest request, Func<string, T> parse)
	{
		request.Headers.TryGetValue(key, out var value);

		if (value.Any())
		{
			string? headerValue = value.First();

			var headerValueNotNull = "";
			if(headerValue is not null)
			{
				headerValueNotNull = headerValue;
			}

			return parse(headerValueNotNull);
		}
		return parse("");
	}

	public static string GetOriginalHost(HttpRequest request)
	{
		string source = "";
		var originalHost = request.Headers.Where(pair => pair.Key.Contains("X-ORIGINAL-HOST", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
		
		if(!string.IsNullOrEmpty(originalHost.Value))
		{
			source = $"ORIGINAL-HOST:{originalHost.Value}/";
		}

		var host = request.Host;
		if (host.Host != "")
		{
			source += $"Host:{host.Host}/";
		}

		var xForward = request.Headers.SingleOrDefault(pair => pair.Key.Contains("X-FORWARDED-FOR", StringComparison.InvariantCultureIgnoreCase));
		if (!string.IsNullOrEmpty(xForward.Value))
		{
			source += $"FORWARDED-FOR:{xForward}";
		}

		return source.TrimEnd('/');
	}
}
