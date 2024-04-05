namespace Domain.Messages;

public class Message
{
	// Base information
	public Guid Id { get; set; }
	public DateTimeOffset CreateTime { get; set; }
	public DateTimeOffset UpdateTime { get; set; }
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
}
