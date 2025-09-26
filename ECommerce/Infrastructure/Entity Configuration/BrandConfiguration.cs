using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Entity_Configuration
{
	public sealed class BrandConfiguration : IEntityTypeConfiguration<Brand>
	{
		public void Configure(EntityTypeBuilder<Brand> builder)
		{
			builder.HasKey(brand => brand.Id);

			builder.Property(brand => brand.Name)
				.IsRequired()
				.HasMaxLength(100);
		}
	}
}
