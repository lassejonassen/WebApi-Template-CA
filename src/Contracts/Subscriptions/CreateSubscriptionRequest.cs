using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Common;

namespace Contracts.Subscriptions;

public record CreateSubscriptionRequest(
	string FirstName,
	string LastName,
	string Email,
	SubscriptionType SubscriptionType);