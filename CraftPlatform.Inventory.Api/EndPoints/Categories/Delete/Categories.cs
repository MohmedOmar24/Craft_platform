using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Delete
{
    public static class Categories
    {
        public static void MapCategoriesDeleteEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapDelete(CategoriesRoutes.Delete, async ([FromRoute] Guid categoryId, [FromServices] ICategoriesService categoriesService) =>
            {
                var result = await categoriesService.DeleteCategory(categoryId);
               return result.Succeeded?Results.Ok():result.ToProblem(result.Error.ToStatusCode());

            });
        }
    }
}
