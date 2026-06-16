using CraftPlatform.Inventory.Api.EndPoints.Categories.Read;
using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.ReadById
{
    public static class Categories
    {
        public static void MapCategoriesReadByIdEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet(CategoriesRoutes.ReadById, async ([FromRoute] Guid categoryId, [FromServices] ICategoriesService categoriesService) =>
            {
                var result = await categoriesService.ReadCategoryById(categoryId);
                return result.Succeeded ? Results.Ok(
                   new CategoriesReadResponse(result.Value.Name,
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
