using Application.Dtos.Product_Dtos;
using Application.Interfaces.Generic_Repository_Interface;
using AutoMapper;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repository_Service
{
	public sealed class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
	{
		private readonly ECommerceContext context;

		public GenericRepository(ECommerceContext context)
		{
			this.context = context;
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
					.FindAsync(id);

				return product as TEntity;
			}

			var entity = await context.Set<TEntity>()
				.Where(entity => entity.Id == id)
				.FirstOrDefaultAsync();

			return entity;
		}

		public void AddAsync(TEntity InputEntity)
		{
			context.Set<TEntity>().Add(InputEntity);
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
