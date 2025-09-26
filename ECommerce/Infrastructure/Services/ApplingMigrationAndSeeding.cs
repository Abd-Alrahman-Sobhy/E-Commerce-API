using Infrastructure.Context;
using Infrastructure.Services.Data_Seeding_Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
	public class ApplingMigrationAndSeeding
	{
		public static async Task MigrateAndSeedAsync(IServiceProvider serviceProvider)
		{
			using var scope = serviceProvider.CreateScope();
			var services = scope.ServiceProvider;
			var logger = services.GetRequiredService<ILogger<ApplingMigrationAndSeeding>>();

			try
			{
				var dataBase = services.GetRequiredService<ECommerceContext>();

				await dataBase.Database.MigrateAsync();

				logger.LogInformation("Database Migrated.");

				await DataSeeding.BrandSeeding(dataBase);
				await DataSeeding.ProductTypeSeeding(dataBase);
				await DataSeeding.ProductSeeding(dataBase);

				logger.LogInformation("Data seeding applyed succefully.");
			}
			catch (Exception e)
			{
				logger.LogError(e, "An error occured while migrating or seeding.");
				throw;
			}
		}
	}
}
