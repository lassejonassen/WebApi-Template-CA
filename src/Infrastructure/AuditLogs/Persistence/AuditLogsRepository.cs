using Application.Common.Interfaces;
using Domain.Audit;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AuditLogs.Persistence;
public class AuditLogsRepository(AppDbContext _dbContext) : IAuditLogsRepository
{
	public async Task CreateAuditLog(AuditLog auditLog)
	{
		await _dbContext.AuditLogs.AddAsync(auditLog);
		await _dbContext.SaveChangesAsync();
	}

	public async Task<List<AuditLog>> GetAuditLogsForEntity(string entityType, string entityId)
	{
		return await _dbContext.AuditLogs
			.Where(x => x.EntityType == entityType && x.EntityId == entityId)
			.OrderBy(x => x.CreateTime)
			.ToListAsync();
	}
}
