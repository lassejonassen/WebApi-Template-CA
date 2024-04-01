using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Database;
using Persistence.Entities;

using DomainAuditLog = Domain.Models.Audit.AuditLog;
using DomainAuditLogCreate = Domain.Models.Audit.AuditLogCreate;
using EntityAuditLog = Persistence.Entities.AuditLog;

namespace Persistence.Repositories
{
	public class AuditLogRepository(ApplicationDbContext context, ILogger logger) : BaseRepository(context), IAuditLogRepository
	{
		private readonly ILogger _logger = logger;

		private IQueryable<EntityAuditLog> Entities => DbContext.AuditLogs;

		public Task<DomainAuditLog> CreateAuditLogAsync(DomainAuditLogCreate auditCreate)
		{
			throw new NotImplementedException();
		}

		public async Task<List<DomainAuditLog>> GetAuditLogsForEntityAsync(string entityType, string entityId)
		{
			return await Entities
				.Where(x => x.EntityType == entityType && x.EntityId == entityId)
				.OrderBy(x => x.CreateTime)
				.Select(x => x.ToDomain())
				.ToListAsync();
		}

		private EntityAuditLog GenerateAuditLogCreationModel(DomainAuditLogCreate create) => new()
		{
			Id = Guid.NewGuid(),
			CreateTime = DateTimeOffset.Now,
			UpdateTime = null,
			EntityType = create.EntityType,
			EntityId = create.EntityId,
			ChangedByCommand = create.ChangedByCommand,
			CommandId = create.CommandId,
			ChangedByUser = create.ChangedByUser,
			Content = create.Content,
			CorrelationId = Guid.NewGuid()
		};
	}
}
