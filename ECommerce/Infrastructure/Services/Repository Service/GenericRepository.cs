using Application.Dtos.Product_Dtos;
using Application.Interfaces.Generic_Repository_Interface;
using AutoMapper;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repository_Service
{
	public sealed class GenericRepository<TEntity, TOutputDto> : IGenericRepository<TEntity, TOutputDto> where TEntity : BaseEntity
	{
		private readonly ECommerceContext context;
		private readonly IMapper mapper;

		public GenericRepository(IMapper mapper, ECommerceContext context)
		{
			this.mapper = mapper;
			this.context = context;
		}

		public async Task<IEnumerable<TOutputDto>> GetAllAsync()
		{
			if (typeof(TEntity) == typeof(Product))
			{
				var products = await context.Products
					.Include(product => product.Brand)
					.Include(product => product.ProductType)
					.ToListAsync();
				return mapper.Map<IEnumerable<TOutputDto>>(products);
			}
			var entities = await context.Set<TEntity>().ToListAsync();
			return mapper.Map<IEnumerable<TOutputDto>>(entities);
		}

		public async Task<TOutputDto?> GetByIdAsync(int id)
		{
			if (typeof(TEntity) == typeof(Product))
			{
				var product = await context.Products
					.FindAsync(id);

				return mapper.Map<TOutputDto>(product);
			}

			var entity = await context.Set<TEntity>()
				.Where(entity => entity.Id == id)
				.FirstOrDefaultAsync();

			return mapper.Map<TOutputDto>(entity);
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
