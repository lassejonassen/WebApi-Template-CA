using Application.Common.Interfaces;
using Domain.Users;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users.Persistence;

public class UsersRepository(AppDbContext _dbContext) : IUsersRepository
{
	public async Task AddAsync(User user, CancellationToken cancellationToken)
	{
		await _dbContext.AddAsync(user, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
		//return await _dbContext.SubUsers.FindAsync([userId], cancellationToken: cancellationToken);
	}

	public async Task<User> GetBySubscriptionIdAsync(Guid subscriptionId, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
		//return await _dbContext.SubUsers.FirstOrDefaultAsync(user => user.Subscription.Id == subscriptionId, cancellationToken);
	}

	public async Task RemoveAsync(User user, CancellationToken cancellationToken)
	{
		_dbContext.Remove(user);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task UpdateAsync(User user, CancellationToken cancellationToken)
	{
		_dbContext.Update(user);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
}