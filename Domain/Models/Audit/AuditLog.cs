namespace Domain.Models.Audit
{
	public record AuditLog
	{
		public required Guid Id { get; set; }
		public DateTimeOffset? CreateTime { get; set; }
		public required string EntityType { get; set; }
		public required string EntityId { get; set; }
		public string? ChangedByCommand { get; set; }
		public string? CommandId { get; set; }
		public string? ChangedByuser { get; set; }
		public required string Content { get; set; }
		public required Guid CorrelationId { get; set; }
	}
}
