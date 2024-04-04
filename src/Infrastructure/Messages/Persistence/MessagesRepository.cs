using Application.Common.Interfaces;
using Domain.Messages;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Messages.Persistence;

public class MessagesRepository(AppDbContext _dbContext) : IMessagesRepository
{
	public async Task AddAsync(Message message, CancellationToken cancellationToken)
	{
		await _dbContext.AddAsync(message, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task<List<Message>> GetMessagesAsync(CancellationToken cancellationToken)
	{
		return await _dbContext.Messages.OrderBy(x => x.CreateTime).ToListAsync(cancellationToken);
	}

	public async Task<Message> GetMessageByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		return await _dbContext.Messages.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
	}

	public async Task UpdateAsync(Message message, CancellationToken cancellationToken)
	{
		_dbContext.Update(message);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task RemoveAsync(Message message, CancellationToken cancellationToken)
	{
		_dbContext.Remove(message);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task RemoveRangeAsync(List<Message> messages, CancellationToken cancellationToken)
	{
		_dbContext.RemoveRange(messages);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
}
