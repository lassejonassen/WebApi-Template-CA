using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Api.Helpers;

public static class ContextHelpers
{
	public static Guid GetUserId(HttpContext context)
	{
		try
		{
			string accessToken = context.Request.Headers.Authorization.ToString().Replace("Bearer ", string.Empty);
			var handler = new JwtSecurityTokenHandler();
			var token = handler.ReadJwtToken(accessToken);
				
			string userId = token.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

			return Guid.Parse(userId);
		}
		catch
		{
			return Guid.Empty;
		}
	}

	public static string GetUniqueName(HttpContext context) {
		try
		{
			string accessToken = context.Request.Headers.Authorization.ToString().Replace("Bearer ", string.Empty);
			var handler = new JwtSecurityTokenHandler();
			var token = handler.ReadJwtToken(accessToken);

			string uniqueName = token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

			return uniqueName;
		}
		catch
		{
			return "";
		}
	}
}
