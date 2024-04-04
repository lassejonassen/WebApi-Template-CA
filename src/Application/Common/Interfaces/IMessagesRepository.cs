using Domain.Messages;

namespace Application.Common.Interfaces;

public interface IMessagesRepository
{
	Task AddAsync(Message message, CancellationToken cancellationToken);
	Task<List<Message>> GetMessagesAsync(CancellationToken cancellationToken);
	Task<Message> GetMessageByIdAsync(Guid id, CancellationToken cancellationToken);
	Task UpdateAsync(Message message, CancellationToken cancellationToken);
	Task RemoveAsync(Message message, CancellationToken cancellationToken);
	Task RemoveRangeAsync(List<Message> messages, CancellationToken cancellationToken);
}
