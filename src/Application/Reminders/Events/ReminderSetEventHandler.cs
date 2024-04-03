﻿using Application.Common.Interfaces;
using Domain.Users.Events;
using MediatR;

namespace Application.Reminders.Events;
public class ReminderSetEventHandler(IRemindersRepository _remindersRepository) : INotificationHandler<ReminderSetEvent>
{
	public async Task Handle(ReminderSetEvent @event, CancellationToken cancellationToken)
	{
		await _remindersRepository.AddAsync(@event.Reminder, cancellationToken);
	}
}