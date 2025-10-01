using API.Filters;
using Application.Dtos.Product_Dtos;
using Application.Interfaces.Unit_Of_Work_Interface;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductOutputDto>>> GetAll()
		{
			var productRepository = unitOfWork.Repository<Product>();

			var products = await productRepository!.GetAllAsync();

			return Ok(mapper.Map<IEnumerable<ProductOutputDto>>(products));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductOutputDto>> Get(int id)
		{
			var productRepository = unitOfWork.Repository<Product>();
			var product = await productRepository!.GetByIdAsync(id);

			return Ok(mapper.Map<ProductOutputDto>(product));
		}

		[HttpPost("create")]
		public async Task<ActionResult> Create([FromBody] ProductInputDto inputProduct)
		{
			var productToAdd = mapper.Map<Product>(inputProduct);
			var productRepository = unitOfWork.Repository<Product>();
			productRepository!.AddAsync(productToAdd);
			await unitOfWork.CompleteAsync();

			return Created();
		}
	}
}
