using Application.Common.Interfaces;
using Domain.Users.Events;
using MediatR;

namespace Application.Subscriptions.Events;

public class SubscriptionCanceledEventHandler(IUsersRepository _usersRepository)
	: INotificationHandler<SubscriptionCanceledEvent>
{
	public async Task Handle(SubscriptionCanceledEvent notification, CancellationToken cancellationToken)
	{
		notification.User.DeleteAllReminders();

		await _usersRepository.RemoveAsync(notification.User, cancellationToken);
	}
}