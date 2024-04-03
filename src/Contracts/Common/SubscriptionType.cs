using System.Text.Json.Serialization;

namespace Contracts.Common;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubscriptionType
{
	Basic,
	Pro,
}