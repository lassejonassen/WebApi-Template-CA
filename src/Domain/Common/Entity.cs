﻿namespace Domain.Common;

public abstract class Entity
{
	public Guid Id { get; set; }
	public DateTimeOffset CreateTime { get; set; }
	public DateTimeOffset UpdateTime { get; set; }

	protected readonly List<IDomainEvent> _domainEvents = [];

	protected Entity(Guid id)
	{
		Id = id;
	}

	public List<IDomainEvent> PopDomainEvents()
	{
		var copy = _domainEvents.ToList();
		_domainEvents.Clear();

		return copy;
	}


	protected Entity() { }
}
