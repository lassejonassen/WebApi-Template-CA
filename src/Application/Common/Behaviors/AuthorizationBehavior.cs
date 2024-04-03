﻿using System.Reflection;
using Application.Common.Interfaces;
using Application.Common.Security.Request;
using ErrorOr;
using MediatR;

namespace Application.Common.Behaviors;
public class AuthorizationBehavior<TRequest, TResponse>(
	IAuthorizationService _authorizationService)
		: IPipelineBehavior<TRequest, TResponse>
			where TRequest : IAuthorizeableRequest<TResponse>
			where TResponse : IErrorOr
{
	public async Task<TResponse> Handle(
	   TRequest request,
	   RequestHandlerDelegate<TResponse> next,
	   CancellationToken cancellationToken)
	{
		var authorizationAttributes = request.GetType()
			.GetCustomAttributes<AuthorizeAttribute>()
			.ToList();

		if (authorizationAttributes.Count == 0)
		{
			return await next();
		}

		var requiredPermissions = authorizationAttributes
			.SelectMany(authorizationAttribute => authorizationAttribute.Permissions?.Split(',') ?? [])
			.ToList();

		var requiredRoles = authorizationAttributes
			.SelectMany(authorizationAttribute => authorizationAttribute.Roles?.Split(',') ?? [])
			.ToList();

		var requiredPolicies = authorizationAttributes
			.SelectMany(authorizationAttribute => authorizationAttribute.Policies?.Split(',') ?? [])
			.ToList();

		var authorizationResult = _authorizationService.AuthorizeCurrentUser(
			request,
			requiredRoles,
			requiredPermissions,
			requiredPolicies);

		return authorizationResult.IsError
			? (dynamic)authorizationResult.Errors
			: await next();

	}
}
