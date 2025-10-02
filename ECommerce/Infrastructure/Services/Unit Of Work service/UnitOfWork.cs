using Application.Interfaces.Generic_Repository_Interface;
using Application.Interfaces.Unit_Of_Work_Interface;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Services.Repository_Service;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace Infrastructure.Services.Unit_Of_Work_service
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		private readonly ECommerceContext context;
		private readonly ILoggerFactory loggerFactory;
		Hashtable Repositories;

		public UnitOfWork(ECommerceContext context, ILoggerFactory loggerFactory = null)
		{
			this.context = context;
			this.Repositories = new Hashtable();
			this.loggerFactory = loggerFactory;
		}

		public IGenericRepository<TEntity>? Repository<TEntity>() where TEntity : BaseEntity
		{
			var key = typeof(TEntity).Name;
			if (!Repositories.ContainsKey(key))
			{
				var logger = loggerFactory.CreateLogger<GenericRepository<TEntity>>();
				Repositories.Add(key, new GenericRepository<TEntity>(context, logger));
			}

			return Repositories[key] as IGenericRepository<TEntity>;
		}

		public async Task CompleteAsync()
		{
			await context.SaveChangesAsync();
		}

		public void Dispose()
		{
			context.Dispose();
		}
	}
}
