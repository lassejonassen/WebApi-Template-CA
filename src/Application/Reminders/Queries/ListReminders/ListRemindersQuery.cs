using Application.Common.Security.Permissions;
using Application.Common.Security.Policies;
using Application.Common.Security.Request;
using Domain.Reminders;
using ErrorOr;

namespace Application.Reminders.Queries.ListReminders;

[Authorize(Permissions = Permission.Reminder.Get, Policies = Policy.SelfOrAdmin)]
public record ListRemindersQuery(Guid UserId, Guid SubscriptionId) : IAuthorizeableRequest<ErrorOr<List<Reminder>>>;