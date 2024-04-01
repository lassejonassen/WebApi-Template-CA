using Domain.Abstractions;

namespace Domain.Errors
{
	public static class AuditTrailErrors
	{
		public static readonly Error Unknown = new("AuditTrailErrors.Unknown", "Unknown error");
	}
}
