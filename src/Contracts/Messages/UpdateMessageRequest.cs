namespace Contracts.Messages;

public record UpdateMessageRequest(Guid Id, string To, string From, string Text, bool Read) { }