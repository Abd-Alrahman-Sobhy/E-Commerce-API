using Application.Interfaces.Generic_Repository_Interface;
using Domain.Models;

namespace Application.Interfaces.Unit_Of_Work_Interface
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<TEntity>? Repository<TEntity>() where TEntity : BaseEntity;

		public Task CompleteAsync();
	}
}
