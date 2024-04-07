namespace Contracts.Identity;

public class UpdateApplicationUserRequest
{
	public required Guid Id { get; set; }
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
	public string PhoneNumber { get; set; }
}
