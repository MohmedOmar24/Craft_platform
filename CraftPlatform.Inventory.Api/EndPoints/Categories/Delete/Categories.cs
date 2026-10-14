using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Categories;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Delete
{
    public static class Categories
    {
        public static void MapCategoriesDeleteEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapDelete(CategoriesRoutes.Delete, async ([FromRoute]Guid categoryId,InventoryFactory<CategoriesOperationsContract, CategoriesContract> factory) =>
            {
                var service = factory.Build(nameof(Category));
                var result = await service.Delete(categoryId);
               return result.Succeeded?Results.Ok():result.ToProblem(result.Error.ToStatusCode());

            });
        }
    }
}
