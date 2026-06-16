using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Services.CategoriesImplementations;
using Microsoft.Extensions.DependencyInjection;

namespace CraftPlatform.Inventory.Services
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddServiceLayerDependencies(this IServiceCollection services)
        {
            services.AddCategoryService();
            return services;
        }
        private static IServiceCollection AddCategoryService(this IServiceCollection services)
        {
            services.AddScoped<ICategoriesService, CategoriesService>();
            return services;
        }
    }
}
