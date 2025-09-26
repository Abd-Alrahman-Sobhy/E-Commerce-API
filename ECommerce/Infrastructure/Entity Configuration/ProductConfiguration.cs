using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Entity_Configuration
{
	public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(product => product.Id);

			builder.Property(product => product.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(product => product.PictureUrl)
				.IsRequired();

			builder.Property(product => product.Price)
				.IsRequired()
				.HasPrecision(6, 2);

			builder.Property(product => product.Description)
				.HasMaxLength(300);

			builder.HasOne(product => product.Brand)
				.WithMany(brand => brand.Products)
				.HasForeignKey(product => product.ProductBrandId);

			builder.HasOne(product => product.ProductType)
				.WithMany(productType => productType.Products)
				.HasForeignKey(product => product.ProductTypeId);
		}
	}
}
