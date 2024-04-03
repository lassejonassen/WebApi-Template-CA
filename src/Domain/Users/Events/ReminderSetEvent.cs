using Domain.Common;
using Domain.Reminders;

namespace Domain.Users.Events;

public record ReminderSetEvent(Reminder Reminder) : IDomainEvent;