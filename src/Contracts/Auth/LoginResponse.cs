namespace Contracts.Auth;
public record LoginResponse
{
	public required Guid Id { get; set; }
	public required string Token { get; set; }
}
