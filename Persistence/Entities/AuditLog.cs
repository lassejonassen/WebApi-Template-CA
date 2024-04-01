namespace Persistence.Entities
{
	public record AuditLog : BaseEntity
	{
		public required string EntityType { get; set; }
		public required string EntityId { get; set; }
		public string? ChangedByCommand { get; set; }
		public string? CommandId { get; set; }
		public string? ChangedByUser { get; set; }
		public required string Content { get; set; }
		public required Guid CorrelationId { get; set; }
	}
}
