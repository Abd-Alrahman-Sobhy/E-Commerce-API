using Application.Interfaces.Generic_Repository_Interface;
using Application.Interfaces.Unit_Of_Work_Interface;
using Infrastructure.Services.Repository_Service;
using Infrastructure.Services.Unit_Of_Work_service;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
	public static class DependencyInjection
	{
		public static IServiceCollection DependencyService(this IServiceCollection services)
		{
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

			return services;
		}
	}
}
