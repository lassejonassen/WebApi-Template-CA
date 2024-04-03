using Application.Common.Security.Permissions;
using Application.Common.Security.Policies;
using Application.Common.Security.Request;
using Domain.Reminders;
using ErrorOr;

namespace Application.Reminders.Commands.SetReminder;

[Authorize(Permissions = Permission.Reminder.Set, Policies = Policy.SelfOrAdmin)]
public record SetReminderCommand(Guid UserId, Guid SubscriptionId, string Text, DateTime DateTime)
	: IAuthorizeableRequest<ErrorOr<Reminder>>;