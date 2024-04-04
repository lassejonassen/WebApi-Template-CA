namespace Contracts.Messages;

public record CreateMessageRequest(string To, string From, string Text) { }