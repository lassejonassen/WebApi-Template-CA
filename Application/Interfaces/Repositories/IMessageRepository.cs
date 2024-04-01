using Domain.Models;

namespace Application.Interfaces.Repositories
{
	public interface IMessageRepository : IBaseRepository
	{
		Guid Create(Message message);
		IEnumerable<Message> GetAll();
		Message GetById(Guid id);
		bool Update(Guid id, MessageUpdateDraft message);
		bool Delete(Guid id);
	}
}
