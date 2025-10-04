using Application.Dtos.Brand_Dtos;
using Application.Dtos.Product_Dtos;
using Application.Dtos.Type_Dtos;
using AutoMapper;
using Domain.Models;

namespace Infrastructure.Auto_Mapper
{
	public sealed class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<Brand, BrandOutputDto>();
			CreateMap<ProductType, TypeOutputDto>();
			CreateMap<Product, ProductOutputDto>()
				.ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
				.ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.ProductType.Name))
				.ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());

			CreateMap<ProductInputDto, Product>();
		}
	}
}
