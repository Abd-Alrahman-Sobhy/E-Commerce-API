using Domain.Models;

namespace Application.Interfaces.Generic_Repository_Interface
{
	public interface IGenericRepository<TEntity, TOutputDto> where TEntity : BaseEntity
	{
		Task<IEnumerable<TOutputDto>> GetAllAsync();

		Task<TOutputDto?> GetByIdAsync(int id);

		void AddAsync(TEntity InputEntity);

		void UpdateAsync(TEntity InputEntity);

		void DeleteAsync(TEntity id);
	}
}
