namespace Contracts.Identity;

public record ApplicationRoleResponse
{
	public required Guid Id { get; set; }
	public required string Name { get; set; }
	public required string Description { get; set; }

	public DateTimeOffset CreateTime { get; set; }
	public DateTimeOffset UpdateTime { get; set; }
}
