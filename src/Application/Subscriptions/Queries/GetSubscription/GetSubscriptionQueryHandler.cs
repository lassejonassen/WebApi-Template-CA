using Application.Common.Interfaces;
using Application.Subscriptions.Common;
using Domain.Users;
using ErrorOr;
using MediatR;

namespace Application.Subscriptions.Queries.GetSubscription;

public class GetSubscriptionQueryHandler(IUsersRepository _usersRepository)
	: IRequestHandler<GetSubscriptionQuery, ErrorOr<SubscriptionResult>>
{
	public async Task<ErrorOr<SubscriptionResult>> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
	{
		return await _usersRepository.GetByIdAsync(request.UserId, cancellationToken) is User user
			? SubscriptionResult.FromUser(user)
			: Error.NotFound(description: "Subscription not found.");
	}
}