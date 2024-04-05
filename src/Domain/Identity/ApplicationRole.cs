using Microsoft.AspNetCore.Identity;

namespace Domain.Identity;

public class ApplicationRole : IdentityRole
{
	public DateTimeOffset CreateTime { get; set; }
	public DateTimeOffset UpdateTime { get; set; }

	public string Description { get; set; }
}
