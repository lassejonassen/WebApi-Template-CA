using Contracts.Common;

namespace Contracts.Subscriptions;

public record SubscriptionResponse(
	Guid Id,
	Guid UserId,
	SubscriptionType SubscriptionType);