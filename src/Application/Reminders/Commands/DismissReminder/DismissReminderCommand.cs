using Application.Common.Security.Permissions;
using Application.Common.Security.Policies;
using Application.Common.Security.Request;
using ErrorOr;

namespace Application.Reminders.Commands.DismissReminder;

[Authorize(Permissions = Permission.Reminder.Dismiss, Policies = Policy.SelfOrAdmin)]
public record DismissReminderCommand(Guid UserId, Guid SubscriptionId, Guid ReminderId)
	: IAuthorizeableRequest<ErrorOr<Success>>;