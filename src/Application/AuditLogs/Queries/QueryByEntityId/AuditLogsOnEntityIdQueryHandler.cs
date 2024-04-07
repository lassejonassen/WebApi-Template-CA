using Application.Common.Interfaces;
using Domain.Audit;
using ErrorOr;
using MediatR;

namespace Application.AuditLogs.Queries.QueryByEntityId;
public class AuditLogsOnEntityIdQueryHandler(IAuditLogsRepository repo)
	: IRequestHandler<AuditLogsOnEntityIdQuery, ErrorOr<List<AuditLog>>>
{
	public async Task<ErrorOr<List<AuditLog>>> Handle(AuditLogsOnEntityIdQuery query, CancellationToken cancellationToken)
	{
		return await repo.GetAuditLogsForEntity(query.EntityType, query.EntityId);
	}
}
