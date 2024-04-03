using Application.Common.Security.Permissions;
using Application.Common.Security.Policies;
using Application.Common.Security.Request;
using ErrorOr;

namespace Application.Reminders.Commands.DeleteReminder;

[Authorize(Permissions = Permission.Reminder.Delete, Policies = Policy.SelfOrAdmin)]
public record DeleteReminderCommand(Guid UserId, Guid SubscriptionId, Guid ReminderId)
	: IAuthorizeableRequest<ErrorOr<Success>>;