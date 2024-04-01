namespace Persistence.Entities
{
	public record BaseEntity
	{
		public Guid Id { get; set; }
		public DateTimeOffset Created { get; set; }
		public DateTimeOffset Updated { get; set; }
	}
}
