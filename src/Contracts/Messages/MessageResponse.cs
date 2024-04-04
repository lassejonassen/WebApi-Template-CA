namespace Contracts.Messages;

public record MessageResponse(Guid Id, string To, string From, string Text, bool Read) { }
