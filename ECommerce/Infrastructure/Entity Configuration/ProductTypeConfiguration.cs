using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Entity_Configuration
{
	public sealed class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
	{
		public void Configure(EntityTypeBuilder<ProductType> builder)
		{
			builder.HasKey(type => type.Id);

			builder.Property(type => type.Name)
				.IsRequired()
				.HasMaxLength(100);
		}
	}
}
