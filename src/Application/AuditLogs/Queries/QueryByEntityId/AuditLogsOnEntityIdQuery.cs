using Contracts.AuditLogs;
using Domain.Audit;
using ErrorOr;
using MediatR;

namespace Application.AuditLogs.Queries.QueryByEntityId;
public record AuditLogsOnEntityIdQuery(string EntityType, string EntityId)
	: IRequest<ErrorOr<List<AuditLog>>>
{
}
