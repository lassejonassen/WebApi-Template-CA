using Application.Common.Security.Permissions;
using Application.Common.Security.Policies;
using Application.Common.Security.Request;
using Application.Subscriptions.Common;
using ErrorOr;

namespace Application.Subscriptions.Queries.GetSubscription;
[Authorize(Permissions = Permission.Subscription.Get, Policies = Policy.SelfOrAdmin)]
public record GetSubscriptionQuery(Guid UserId)
	: IAuthorizeableRequest<ErrorOr<SubscriptionResult>>;