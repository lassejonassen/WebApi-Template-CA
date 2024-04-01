using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Database
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
		public DbSet<AuditTrailEntity> AuditTrails => Set<AuditTrailEntity>();
		public DbSet<MessageEntity> Messages => Set<MessageEntity>();
	}
}
