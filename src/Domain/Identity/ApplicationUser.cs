using Microsoft.AspNetCore.Identity;

namespace Domain.Identity;

public class ApplicationUser : IdentityUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }

    public DateTimeOffset CreateTime { get; set; }
    public DateTimeOffset UpdateTime { get; set; }

	// RefreshToken
	public string RefreshToken { get; set; } = string.Empty;
    public DateTime TokenCreated { get; set; }
	public DateTime TokenExpires { get; set; }
}
