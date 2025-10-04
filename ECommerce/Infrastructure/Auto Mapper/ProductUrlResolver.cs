using Application.Dtos.Product_Dtos;
using AutoMapper;
using Domain.Models;

namespace Infrastructure.Auto_Mapper;

public sealed class ProductUrlResolver : IValueResolver<Product, ProductOutputDto, string>
{
	public string Resolve(Product source, ProductOutputDto destination, string destMember, ResolutionContext context)
	{
		if (string.IsNullOrEmpty(source.PictureUrl))
			return string.Empty;
		else
			return $"https://localhost:7094/{source.PictureUrl}";
	}
}
