namespace Application.Dtos.Product_Dtos;

public sealed class ProductQueryParameters
{
	public int? PageNumber { get; set; }
	public int? PageSize { get; set; }
	public string? Sort { get; set; }
	public string? Search { get; set; }
	public decimal? MinPrice { get; set; }
	public decimal? MaxPrice { get; set; }
}
