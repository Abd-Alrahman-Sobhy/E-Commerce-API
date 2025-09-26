using Infrastructure.Auto_Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
	public static class ApplyingAutoMapper
	{
		public static IServiceCollection AutoMapperConfiguration(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MapperProfile));

			return services;
		}
	}
}
