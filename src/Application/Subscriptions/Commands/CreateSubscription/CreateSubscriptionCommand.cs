using Application.Common.Security.Permissions;
using Application.Common.Security.Policies;
using Application.Common.Security.Request;
using Application.Subscriptions.Common;
using Domain.Users;
using ErrorOr;

namespace Application.Subscriptions.Commands.CreateSubscription;

[Authorize(Permissions = Permission.Subscription.Create, Policies = Policy.SelfOrAdmin)]
public record CreateSubscriptionCommand(
	Guid UserId,
	string FirstName,
	string LastName,
	string Email,
	SubscriptionType SubscriptionType)
	: IAuthorizeableRequest<ErrorOr<SubscriptionResult>>;