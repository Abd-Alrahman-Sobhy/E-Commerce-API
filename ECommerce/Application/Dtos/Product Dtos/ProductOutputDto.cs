namespace Application.Dtos.Product_Dtos
{
	public sealed class ProductOutputDto
	{
		public int Id
		{
			get; set;
		}

		public string Name
		{
			get; set;
		} = null!;

		public string Description
		{
			get; set;
		} = null!;

		public string PictureUrl
		{
			get; set;
		} = null!;

		public decimal Price
		{
			get; set;
		}

		public string BrandName
		{
			get; set;
		} = null!;

		public string TypeName
		{
			get; set;
		} = null!;
	}
}
