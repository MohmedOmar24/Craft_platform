using CraftPlatform.Inventory.Api.EndPoints.Categories.Read;
using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Categories;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.ReadById
{
    public static class Categories
    {
        public static void MapCategoriesReadByIdEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet(CategoriesRoutes.ReadById, async ([FromRoute] Guid categoryId, InventoryFactory<CategoriesOperationsContract, CategoriesContract> factory) =>
            {
                var service = factory.Build(nameof(Category));
                var result = await service.ReadById(categoryId);
                return result.Succeeded ? Results.Ok(
                   new ReadCategoriesResponse(result.Value.CategoryId,
                                                   result.Value.Name,
                                                   result.Value.Description,
                                                   result.Value.CreatedBy,
                                                   result.Value.UpdatedBy,
                                                   result.Value.CreatedAt,
                                                   result.Value.UpdatedAt))
                
                : result.ToProblem(result.Error.ToStatusCode());
            });
        }
    }
}
