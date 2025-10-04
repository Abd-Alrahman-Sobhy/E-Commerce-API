using Domain.Models;

namespace Application.Specifications;

public sealed class ProductSpecification : BaseSpecification<Product>
{
	public ProductSpecification(string? search = null, string? sort = null, decimal? minPrice = null, decimal? maxPrice = null)
	{
		AddInclude(p => p.Brand);
		AddInclude(p => p.ProductType);

		if (minPrice.HasValue)
			AddCriteria(p => p.Price >= minPrice.Value);

		if (maxPrice.HasValue)
			AddCriteria(p => p.Price <= maxPrice.Value);

		if (!string.IsNullOrWhiteSpace(search))
			AddCriteria(p => p.Name.Contains(search));

		if (!string.IsNullOrEmpty(sort))
		{
			switch (sort.ToLower())
			{
				case "priceasc":
					ApplyOrderBy(q => q.OrderBy(p => p.Price));
					break;
				case "pricedesc":
					ApplyOrderByDescending(q => q.OrderByDescending(p => p.Price));
					break;
				case "nameasc":
					ApplyOrderBy(q => q.OrderBy(p => p.Name));
					break;
				case "namedesc":
					ApplyOrderByDescending(q => q.OrderByDescending(p => p.Name));
					break;
			}
		}
	}
}
