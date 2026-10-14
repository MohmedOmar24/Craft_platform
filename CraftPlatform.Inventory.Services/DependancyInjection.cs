using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Services.CategoriesImplementations;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Services.ProductsImplementations;
using Microsoft.Extensions.DependencyInjection;

namespace CraftPlatform.Inventory.Services
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddServiceLayerDependencies(this IServiceCollection services)
        {
            services.AddInventoryFactory();
            services.AddCategoryService();
            services.AddProductService();
            return services;
        }
       
        
        
        
        private static IServiceCollection AddInventoryFactory(this IServiceCollection services)
        {
            services.AddScoped(typeof(InventoryFactory<,>));
            return services;
        }
        private static IServiceCollection AddCategoryService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericServices<,>), typeof(CategoriesService<,>));
            return services;
        }
        private static IServiceCollection AddProductService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericServices<,>), typeof(ProductsServices<,>));
            return services;
        }
    }
}
