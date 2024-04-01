using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Repositories
{
	public class BaseRepository : IBaseRepository
	{
		protected readonly ApplicationDbContext DbContext;

		protected BaseRepository(ApplicationDbContext context)
		{
			DbContext = context;
		}

		public async Task CommitAsync()
		{
			await DbContext.SaveChangesAsync();
		}

		public void Rollback()
		{
			foreach (var entry in DbContext.ChangeTracker.Entries())
			{
				entry.State = entry.State switch
				{
					EntityState.Added => EntityState.Detached,
					EntityState.Modified => EntityState.Unchanged,
					EntityState.Deleted => EntityState.Unchanged,
					_ => entry.State
				};
			}
		}
	}
}
