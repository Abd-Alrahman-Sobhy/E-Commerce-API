using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
	public sealed class ECommerceContext : DbContext
	{
		public DbSet<Product> Products
		{
			get; set;
		}

		public DbSet<Brand> Brands
		{
			get; set;
		}

		public DbSet<ProductType> Types
		{
			get; set;
		}

		public ECommerceContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceContext).Assembly);
		}
	}
}
