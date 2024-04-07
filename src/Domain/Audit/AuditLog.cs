namespace Domain.Audit;

public class AuditLog
{
	// Base information
	public Guid Id { get; set; }
	public DateTimeOffset CreateTime { get; set; }
	public DateTimeOffset UpdateTime { get; set; }
	public Guid CorrelationId { get; set; }

	// Specific information
	public required string EntityType { get; set; }
	public required string EntityId { get; set; }
	public string? ChangedByCommand { get; set; }
	public string? CommandId { get; set; }
	public string? ChangedByUser { get; set; }
	public required string Content {  get; set; }	
}
