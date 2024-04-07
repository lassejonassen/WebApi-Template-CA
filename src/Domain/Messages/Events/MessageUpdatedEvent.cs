using Domain.Common;

namespace Domain.Messages.Events;
public record MessageUpdatedEvent(Message Message) : IDomainEvent
{
}
