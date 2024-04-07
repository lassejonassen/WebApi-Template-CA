using Contracts.AuditLogs;
using Domain.Audit;
using ErrorOr;
using MediatR;

namespace Application.AuditLogs.Commands.Create;
public record CreateAuditLogCommand(CreateAuditLogRequest Request)
	: IRequest<ErrorOr<AuditLog>>
{
}
