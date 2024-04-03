using Application.Common.Security.Permissions;
using Application.Common.Security.Policies;
using Application.Common.Security.Request;
using Domain.Reminders;
using ErrorOr;

namespace Application.Reminders.Queries.GetReminder;
[Authorize(Permissions = Permission.Reminder.Get, Policies = Policy.SelfOrAdmin)]
public record GetReminderQuery(Guid UserId, Guid SubscriptionId, Guid ReminderId) : IAuthorizeableRequest<ErrorOr<Reminder>>;