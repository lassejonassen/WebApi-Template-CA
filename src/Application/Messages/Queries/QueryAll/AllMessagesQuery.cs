using Application.Common.Security.Request;
using Application.Common.Security.Roles;
using Contracts.Messages;
using ErrorOr;

namespace Application.Messages.Queries;

[Authorize(Roles = Role.User)]
public record AllMessagesQuery(Guid UserId) : IAuthorizeableRequest<ErrorOr<List<MessageResponse>>> { }
