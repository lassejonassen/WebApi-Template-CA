namespace Contracts.Identity;

public record ApplicationUserResponse
{
	public required Guid Id { get; set; }
	public required string FirstName { get; set; }
	public required string LastName { get; set;}
	public string UserName { get; set;}
	public string Email { get; set;}
	public string PhoneNumber { get; set;}

	public DateTimeOffset CreateTime { get; set; }
	public DateTimeOffset UpdateTime { get; set; }
}
