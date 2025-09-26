using Application.Dtos.Product_Dtos;
using Application.Dtos.Type_Dtos;
using Application.Interfaces.Unit_Of_Work_Interface;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TypeController : ControllerBase
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public TypeController(IMapper mapper, IUnitOfWork unitOfWork)
		{
			this.mapper = mapper;
			this.unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TypeOutputDto>>> GetAll()
		{
			var typeRepository = unitOfWork.Repository<ProductType>();
			var productTypes = await typeRepository!.GetAllAsync();

			return Ok(mapper.Map<IEnumerable<TypeOutputDto>>(productTypes));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TypeOutputDto>> Get(int id)
		{
			var typeRepository = unitOfWork.Repository<ProductType>();
			var productType = await typeRepository!.GetByIdAsync(id);

			if (productType == null)
				return NotFound();

			return Ok(mapper.Map<TypeOutputDto>(productType));
		}

		[HttpGet("{id}/products")]
		public async Task<ActionResult<IEnumerable<ProductOutputDto>>> GetProductByTypeId(int id)
		{
			var productRepository = unitOfWork.Repository<Product>();
			var products = await productRepository!.GetAllAsync();
			var productByTypeId = products.Where(product => product.ProductTypeId == id).ToList();
			if (productByTypeId.Any())
			{
				return Ok(mapper.Map<IEnumerable<ProductOutputDto>>(productByTypeId));
			}

			return NotFound();
		}
	}
}
