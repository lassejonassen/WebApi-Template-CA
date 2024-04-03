using Domain.Common;

namespace Domain.Users.Events;

public record ReminderDismissedEvent(Guid ReminderId) : IDomainEvent;