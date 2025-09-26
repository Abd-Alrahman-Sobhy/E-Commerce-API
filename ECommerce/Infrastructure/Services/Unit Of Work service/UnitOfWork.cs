using Application.Interfaces.Generic_Repository_Interface;
using Application.Interfaces.Unit_Of_Work_Interface;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Services.Repository_Service;
using System.Collections;

namespace Infrastructure.Services.Unit_Of_Work_service
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		private readonly ECommerceContext context;
		Hashtable Repositories;

		public UnitOfWork(ECommerceContext context)
		{
			this.context = context;
			this.Repositories = new Hashtable();
		}

		public IGenericRepository<TEntity>? Repository<TEntity>() where TEntity : BaseEntity
		{
			var key = typeof(TEntity).Name;
			if (!Repositories.ContainsKey(key))
			{
				Repositories.Add(key, new GenericRepository<TEntity>(context));
			}

			return Repositories[key] as IGenericRepository<TEntity>;
		}

		public int Complete()
		{
			return context.SaveChanges();
		}

		public void Dispose()
		{
			context.Dispose();
		}
	}
}
