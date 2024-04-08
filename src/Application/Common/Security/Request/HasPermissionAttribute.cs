using Application.Common.Security.Permissions;
using Application.Common.Security.Policies;

using AuthorizeAttr = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace Application.Common.Security.Request;

public sealed class HasPermissionAttribute(PermissionEnum permission) 
	: AuthorizeAttr(policy: permission.ToString())
{
}
