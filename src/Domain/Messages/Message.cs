using Domain.Common;
using Domain.Messages.Events;
using ErrorOr;

namespace Domain.Messages;

public class Message : Entity
{
	public Guid CorrelationId { get; set; }

	// Specific information
	public string To { get; set; }
	public string From { get; set; }
	public string Text { get; set; }
	public bool Read { get; set; }

	// Create Constructor
	public Message(Guid id, DateTimeOffset createTime, Guid correlationId, string to, string from, string text, bool read)
	{
		Id = id;
		CreateTime = createTime;
		CorrelationId = correlationId;
		To = to;
		From = from;
		Text = text;
		Read = read;
	}

	public Message() { }

	public ErrorOr<Success> UpdateMessage()
	{
		_domainEvents.Add(new MessageUpdatedEvent(this));

		return Result.Success;
	}
}
