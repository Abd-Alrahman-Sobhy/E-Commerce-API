using Domain.Models;

namespace Application.Interfaces.Generic_Repository_Interface
{
	public interface IGenericRepository<TEntity> where TEntity : BaseEntity
	{
		Task<IEnumerable<TEntity>> GetAllAsync();

		Task<TEntity?> GetByIdAsync(int id);

		void AddAsync(TEntity InputEntity);

		void UpdateAsync(TEntity InputEntity);

		void DeleteAsync(TEntity id);
	}
}
