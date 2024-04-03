﻿namespace Application.Common.Security.Permissions;

public static partial class Permission
{
	public static class Subscription
	{
		public const string Create = "create:subscription";
		public const string Delete = "delete:subscription";
		public const string Get = "get:subscription";
	}
}