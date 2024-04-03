using Domain.Users;

namespace Application.Tokens.Queries.Generate;

public record GenerateTokenResult(
	Guid Id,
	string FirstName,
	string LastName,
	string Email,
	SubscriptionType SubscriptionType,
	string Token);