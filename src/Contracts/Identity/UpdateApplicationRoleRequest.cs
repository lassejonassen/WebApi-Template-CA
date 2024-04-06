﻿namespace Contracts.Identity;

public record UpdateApplicationRoleRequest
{
	public required Guid Id { get; set; }
	public required string Name { get; set; }
	public required string Description { get; set; }
}
