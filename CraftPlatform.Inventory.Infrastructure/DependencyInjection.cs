using CraftPlatform.Inventory.Infrastructure.Data;
using CraftPlatform.Inventory.Infrastructure.Repositories;
using CraftPlatform.Inventory.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CraftPlatform.Inventory.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInvenoryDBContext(configuration);
            services.AddCategoryRepository();
            services.AddGenericRepository();

            return services;
        }

        
        
        private static IServiceCollection AddInvenoryDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var InventoryDbConnectionString = configuration.GetConnectionString("InventoryDbConnectionString");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(InventoryDbConnectionString));
            return services;
        }
        private static IServiceCollection AddCategoryRepository(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            return services;
        }
        private static IServiceCollection AddGenericRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            return services;
        }
    }
}
