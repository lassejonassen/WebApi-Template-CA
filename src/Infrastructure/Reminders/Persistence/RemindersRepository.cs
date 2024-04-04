using Application.Common.Interfaces;
using Domain.Reminders;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Reminders.Persistence;

public class RemindersRepository(AppDbContext _dbContext) : IRemindersRepository
{
	public async Task AddAsync(Reminder reminder, CancellationToken cancellationToken)
	{
		await _dbContext.AddAsync(reminder, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task<Reminder> GetByIdAsync(Guid reminderId, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
		//return await _dbContext.Reminders.FindAsync(reminderId, cancellationToken);
	}

	public async Task<List<Reminder>> ListBySubscriptionIdAsync(Guid subscriptionId, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
		//return await _dbContext.Reminders
		//	.AsNoTracking()
		//	.Where(reminder => reminder.SubscriptionId == subscriptionId)
		//	.ToListAsync(cancellationToken);
	}

	public async Task RemoveAsync(Reminder reminder, CancellationToken cancellationToken)
	{
		_dbContext.Remove(reminder);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task RemoveRangeAsync(List<Reminder> reminders, CancellationToken cancellationToken)
	{
		_dbContext.RemoveRange(reminders, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task UpdateAsync(Reminder reminder, CancellationToken cancellationToken)
	{
		_dbContext.Update(reminder);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
}
