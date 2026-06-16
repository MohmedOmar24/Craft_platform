using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Read
{
    public static class Categories
    {
        public static void MapCategoriesReadEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet(CategoriesRoutes.BaseUrl, async ([FromServices] ICategoriesService categoriesService) =>
            {
                var result = await categoriesService.ReadCategories();

                return result.Succeeded ? Results.Ok(
                   result.Value.Select(c => new CategoriesReadResponse(c.Name,
                                                                       c.Description,
                                                                       c.CreatedBy,
                                                                       c.UpdatedBy,
                                                                       c.CreatedAt,
                                                                       c.UpdatedAt)).ToList()
                    )
                
                : result.ToProblem(result.Error.ToStatusCode());
            });

        }
}}
