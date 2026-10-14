using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Products;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Products.Delete
{
    public static class Products
    {
        public static void MapProductsDeleteEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapDelete(ProductsRoutes.Delete, async ([FromRoute]Guid productId, InventoryFactory<ProductsOperationsContract, ProductsContract> factory) =>
            {
                var service = factory.Build(nameof(Product));
                var result = await service.Delete(productId);
                return result.Succeeded ? Results.NoContent() : result.ToProblem(result.Error.ToStatusCode());
            });
        }
    }
}
