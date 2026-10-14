using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Categories;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Read
{
    public static class Categories
    {
        public static void MapCategoriesReadEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet(CategoriesRoutes.BaseUrl, async (InventoryFactory<CategoriesOperationsContract, CategoriesContract> factory) =>
            {
                var service = factory.Build(nameof(Category));
                var result = await service.Read(); 

                return result.Succeeded ? Results.Ok(
                   result.Value.Select(c => new ReadCategoriesResponse(c.CategoryId,
                                                                       c.Name,
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
