namespace Application.Interfaces.Repositories
{
	public interface IBaseRepository
	{
		Task CommitAsync();
		void Rollback();
	}
}
