using Application.Interfaces.Generic_Repository_Interface;
using Infrastructure.Services.Repository_Service;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
	public static class DependencyInjection
	{
		public static IServiceCollection DependencyService(this IServiceCollection services)
		{
			services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

			return services;
		}
	}
}
