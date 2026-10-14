using CraftPlatform.Inventory.Api.EndPoints.Categories.Read;
using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Products;

namespace CraftPlatform.Inventory.Api.EndPoints.Products.Read
{
    public static class Products
    {
        public static void MapProductsReadEndPoint (this IEndpointRouteBuilder app)
        {
            app.MapGet(ProductsRoutes.BaseUrl, async (InventoryFactory<ProductsOperationsContract, ProductsContract> factory) =>
            {
                var service = factory.Build(nameof(Product));
                var result = await service.Read();
                return result.Succeeded ? Results.Ok(
                   result.Value.Select(p => new ReadProductsResponse(p.ProductId,
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
                    )

                : result.ToProblem(result.Error.ToStatusCode());

            }
                );
        }
    }
}
