namespace Domain.Models
{
	public sealed class ProductType : BaseEntity
	{
		public string Name
		{
			get; set;
		} = null!;

		public ICollection<Product> Products
		{
			get; set;
		} = new HashSet<Product>();
	}
}
