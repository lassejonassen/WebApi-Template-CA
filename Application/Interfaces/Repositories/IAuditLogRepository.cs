using Domain.Models.Audit;

namespace Application.Interfaces.Repositories
{
	public interface IAuditLogRepository : IBaseRepository
	{
		Task<AuditLog> CreateAuditLogAsync(AuditLogCreate auditCreate);
		Task<List<AuditLog>> GetAuditLogsForEntityAsync(string entityType, string entityId);
	}
}
