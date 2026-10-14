using CraftPlatform.Inventory.Api.EndPoints.Products.Read;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Products;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Products.ReadById
{
    public static class Products
    {
        public static void MapProductsReadByIdEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapGet(ProductsRoutes.ReadById, async ([FromRoute] Guid productId, InventoryFactory<ProductsOperationsContract, ProductsContract> factory) =>
            {
                var service = factory.Build(nameof(Product));
                var product = await service.ReadById(productId);
                if (product == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(new ReadProductsResponse(
                    product.Value.ProductId,
                    product.Value.CategoryId,
                    product.Value.InventoryId,
                    product.Value.Name,
                    product.Value.Description,
                    product.Value.UnitPrice,
                    product.Value.Width,
                    product.Value.Weight,
                    product.Value.Length,
                    product.Value.Height,
                    product.Value.TaxCost,
                    product.Value.ProfitPerUnit,
                    product.Value.ProductionCost
                ));
            });
           
        }
    }
}
