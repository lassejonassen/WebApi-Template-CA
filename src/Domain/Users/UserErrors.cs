using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace Domain.Users;

public static class UserErrors
{
	public static Error CannotCreateMoreRemindersThanSubscriptionAllows { get; } = Error.Validation(
		code: "UserErrors.CannotCreateMoreRemindersThanSubscriptionAllows",
		description: "Cannot create more reminders than subscription allows");
}
