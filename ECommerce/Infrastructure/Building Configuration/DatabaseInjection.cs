using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Building_Configuration
{
	public static class DatabaseInjection
	{
		public static IServiceCollection AddingContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<ECommerceContext>(options => options.UseSqlServer(connectionString));

			return services;
		}
	}
}
