namespace Persistence.Entities
{
	public record BaseEntity
	{
		public Guid Id { get; set; }
		public DateTimeOffset CreateTime { get; set; }
		public DateTimeOffset UpdateTime { get; set; }
	}
}
