﻿namespace Infrastructure.Security.CurrentUserProvider;

public interface ICurrentUserProvider
{
	CurrentUser GetCurrentUser();
}