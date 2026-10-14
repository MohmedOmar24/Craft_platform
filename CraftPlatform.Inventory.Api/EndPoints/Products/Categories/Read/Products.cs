using CraftPlatform.Inventory.Api.EndPoints.Products.Read;
using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Products;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Products.Categories.Read
{
    public static class Products
    {
        public static void MapReadProductsByCategoryIdEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet(ProductsRoutes.ReadByCategoryId, async ([FromRoute]Guid categoryId, InventoryFactory<ProductsOperationsContract, ProductsContract> factory) =>
            {
                var service = factory.Build(nameof(Product));
                var result = await service.ReadByParentId(categoryId);
                return result.Succeeded ?
                Results.Ok(result.Value.Select(p => new ReadProductsResponse(p.ProductId,
                                                                       p.CategoryId,
                                                                       p.InventoryId,
                                                                       p.Name,
                                                                       p.Description,
                                                                       p.UnitPrice,
                                                                       p.Width,
                                                                       p.Weight,
                                                                       p.Length,
                                                                       p.Height,
                                                                       p.TaxCost,
                                                                       p.ProfitPerUnit,
                                                                       p.ProductionCost)).ToList()
                    ):result.ToProblem(result.Error.ToStatusCode());
            });
           
        }
    }
}
