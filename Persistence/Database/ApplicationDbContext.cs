using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Database
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
		public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
		public DbSet<MessageEntity> Messages => Set<MessageEntity>();
	}
}
