using Application.Dtos.Product_Dtos;
using Application.Interfaces.Generic_Repository_Interface;
using AutoMapper;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.Repository_Service
{
	public sealed class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
	{
		private readonly ECommerceContext context;
		private readonly ILogger<GenericRepository<TEntity>> logger;

		public GenericRepository(ECommerceContext context, ILogger<GenericRepository<TEntity>> logger)
		{
			this.context = context;
			this.logger = logger;
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			if (typeof(TEntity) == typeof(Product))
			{
				var products = await context.Products
					.Include(product => product.Brand)
					.Include(product => product.ProductType)
					.ToListAsync();
				return (IEnumerable<TEntity>)products;
			}
			var entities = await context.Set<TEntity>().ToListAsync();
			return entities;
		}

		public async Task<TEntity?> GetByIdAsync(int id)
		{
			if (typeof(TEntity) == typeof(Product))
			{
				var product = await context.Products
					.Include(product => product.Brand)
					.Include(product => product.ProductType)
					.Where(product => product.Id == id)
					.FirstOrDefaultAsync();

				if (product == null)
				{
					throw new Exception("Entity not found");
				}

				return product as TEntity;
			}

			var entity = await context.Set<TEntity>()
				.Where(entity => entity.Id == id)
				.FirstOrDefaultAsync();

			return entity;
		}

		public void AddAsync(TEntity InputEntity)
		{
			logger.LogInformation($"Creating new {typeof(TEntity).Name}.");
			context.Set<TEntity>().Add(InputEntity);
			logger.LogInformation($"{typeof(TEntity).Name} has been created.");
		}

		public void DeleteAsync(TEntity entity)
		{
			context.Set<TEntity>().Remove(entity);
		}

		public void UpdateAsync(TEntity InputEntity)
		{
			context.Set<TEntity>().Update(InputEntity);
		}
	}
}
