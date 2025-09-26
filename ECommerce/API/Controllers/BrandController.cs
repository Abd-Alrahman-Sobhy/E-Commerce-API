using Application.Dtos.Brand_Dtos;
using Application.Dtos.Product_Dtos;
using Application.Interfaces.Unit_Of_Work_Interface;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandController : ControllerBase
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public BrandController(IMapper mapper, IUnitOfWork unitOfWork)
		{
			this.mapper = mapper;
			this.unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<BrandOutputDto>>> GetAll()
		{
			var brandRepository = unitOfWork.Repository<Brand>();
			var brands = await brandRepository!.GetAllAsync();

			return Ok(mapper.Map<IEnumerable<BrandOutputDto>>(brands));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<BrandOutputDto>> Get(int id)
		{
			var brandRepository = unitOfWork.Repository<Brand>();
			var brand = await brandRepository!.GetByIdAsync(id);

			return Ok(mapper.Map<BrandOutputDto>(brand));
		}

		[HttpGet("{id}/products")]
		public async Task<ActionResult<IEnumerable<ProductOutputDto>>> GetProductsBybrandId(int id)
		{
			var productRepository = unitOfWork.Repository<Product>();
			var products = await productRepository!.GetAllAsync();
			var productsByBrandId = products.Where(product => product.ProductBrandId == id).ToList();

			return Ok(mapper.Map<IEnumerable<ProductOutputDto>>(productsByBrandId));
		}
	}
}
