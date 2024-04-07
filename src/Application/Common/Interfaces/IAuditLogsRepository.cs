using Domain.Audit;

namespace Application.Common.Interfaces;
public interface IAuditLogsRepository
{
	Task CreateAuditLog(AuditLog auditLog);
	Task<List<AuditLog>> GetAuditLogsForEntity(string entityType, string entityId);
}
