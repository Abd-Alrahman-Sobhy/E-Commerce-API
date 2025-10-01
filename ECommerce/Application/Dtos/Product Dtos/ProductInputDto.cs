using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Product_Dtos;

public sealed class ProductInputDto
{
	[Required(ErrorMessage = "Product name is required.")]
	[StringLength(100, ErrorMessage = "Product name can't be longer than 100 characters.")]
	public string Name { get; set; } = null!;

	[Required(ErrorMessage = "Description is required.")]
	[StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
	public string Description { get; set; } = null!;

	[Required(ErrorMessage = "Picture URL is required.")]
	public string PictureUrl { get; set; } = null!;

	[Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
	public decimal Price { get; set; }

	[Required(ErrorMessage = "ProductBrandId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "ProductBrandId must be a positive number.")]
	public int ProductBrandId { get; set; }

	[Required(ErrorMessage = "ProductTypeId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "ProductTypeId must be a positive number.")]
	public int ProductTypeId { get; set; }
}
