using Domain.Models;
using Infrastructure.Context;
using System.Text.Json;

namespace Infrastructure.Services.Data_Seeding_Service
{
	public static class DataSeeding
	{
		public static async Task BrandSeeding(ECommerceContext context)
		{
			if (!context.Brands.Any())
			{
				var data = await File.ReadAllTextAsync("../Infrastructure/Services/Data Seeding Service/JsonFiles/brands.json");
				var brands = JsonSerializer.Deserialize<List<Brand>>(data);

				await context.Brands.AddRangeAsync(brands!);
				await context.SaveChangesAsync();
			}
		}

		public static async Task ProductTypeSeeding(ECommerceContext context)
		{
			if (!context.Types.Any())
			{
				var data = await File.ReadAllTextAsync("../Infrastructure/Services/Data Seeding Service/JsonFiles/types.json");
				var productTypes = JsonSerializer.Deserialize<List<ProductType>>(data);

				await context.Types.AddRangeAsync(productTypes!);
				await context.SaveChangesAsync();
			}
		}

		public static async Task ProductSeeding(ECommerceContext context)
		{
			if (!context.Products.Any())
			{
				var data = await File.ReadAllTextAsync("../Infrastructure/Services/Data Seeding Service/JsonFiles/products.json");
				var products = JsonSerializer.Deserialize<List<Product>>(data);

				await context.Products.AddRangeAsync(products!);
				await context.SaveChangesAsync();
			}
		}
	}
}
