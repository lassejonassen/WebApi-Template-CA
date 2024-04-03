using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Security.Permissions;

public static partial class Permission
{
	public static class Message
	{
		public const string Create = "create:message";
		public const string Get = "get:message";
		public const string Update = "update:message";
		public const string Delete = "delete:message";
	}
}
