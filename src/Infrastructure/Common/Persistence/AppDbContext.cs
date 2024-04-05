using Domain.Messages;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<Message> Messages { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

		base.OnModelCreating(modelBuilder);
	}

	//public DbSet<Reminder> Reminders { get; set; } = null!;

	//public DbSet<User> SubUsers { get; set; } = null!;

	//public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	//{
	//	var domainEvents = ChangeTracker.Entries<Entity>()
	//	   .SelectMany(entry => entry.Entity.PopDomainEvents())
	//	   .ToList();

	//	if (IsUserWaitingOnline())
	//	{
	//		AddDomainEventsToOfflineProcessingQueue(domainEvents);
	//		return await base.SaveChangesAsync(cancellationToken);
	//	}

	//	await PublishDomainEvents(domainEvents);
	//	return await base.SaveChangesAsync(cancellationToken);
	//}

	//private bool IsUserWaitingOnline() => _httpContextAccessor.HttpContext is not null;

	//private async Task PublishDomainEvents(List<IDomainEvent> domainEvents)
	//{
	//	foreach (var domainEvent in domainEvents)
	//	{
	//		await _publisher.Publish(domainEvent);
	//	}
	//}

	//private void AddDomainEventsToOfflineProcessingQueue(List<IDomainEvent> domainEvents)
	//{
	//	Queue<IDomainEvent> domainEventsQueue = _httpContextAccessor.HttpContext!.Items.TryGetValue(EventualConsistencyMiddleware.DomainEventsKey, out object value) &&
	//		value is Queue<IDomainEvent> existingDomainEvents
	//			? existingDomainEvents
	//			: new();

	//	domainEvents.ForEach(domainEventsQueue.Enqueue);
	//	_httpContextAccessor.HttpContext.Items[EventualConsistencyMiddleware.DomainEventsKey] = domainEventsQueue;
	//}
}