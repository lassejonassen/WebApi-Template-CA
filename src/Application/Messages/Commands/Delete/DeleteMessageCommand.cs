using Application.Common.Security.Request;
using Application.Common.Security.Roles;
using Contracts.Messages;
using ErrorOr;

namespace Application.Messages.Commands;

[Authorize(Roles = Role.Admin)]
public record DeleteMessageCommand(Guid UserId, Guid Id) : IAuthorizeableRequest<ErrorOr<MessageResponse>>
{ }
