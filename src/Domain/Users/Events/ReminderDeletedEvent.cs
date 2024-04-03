using Domain.Common;

namespace Domain.Users.Events;

public record ReminderDeletedEvent(Guid ReminderId) : IDomainEvent;