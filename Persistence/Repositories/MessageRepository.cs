using Application.Interfaces.Repositories;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Persistence.Database;
using Persistence.Entities;

namespace Persistence.Repositories
{
	public class MessageRepository(ApplicationDbContext context, ILogger logger) : BaseRepository(context), IMessageRepository
	{
		private readonly ILogger _logger = logger;

		private IQueryable<MessageEntity> Entities => DbContext.Messages;

		public Guid Create(Message message)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Message> GetAll()
		{
			throw new NotImplementedException();
		}

		public Message GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public bool Update(Guid id, MessageUpdateDraft message)
		{
			throw new NotImplementedException();
		}
	}
}
