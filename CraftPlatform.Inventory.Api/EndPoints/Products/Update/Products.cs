using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Products;
using Microsoft.AspNetCore.Mvc;


namespace CraftPlatform.Inventory.Api.EndPoints.Products.Update
{
    public static class Products
    {
        public static void MapProductsUpdateEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapPut(ProductsRoutes.Update, async (UpdateProductsRequest request, InventoryFactory<ProductsOperationsContract, ProductsContract> factory) =>
            {
                var service = factory.Build(nameof(Product));
                var result = await service.Update(request.productId, new ProductsOperationsContract
                (
                   request.productId,
                   default,
                   default,
                   request.Body.Name,
                   request.Body.Description,
                   default,
                   default,
                   default,
                   default,
                   default,
                   default,
                   default, 
                   default

                ));
                return result.Succeeded ? 
                Results.Ok() :
                result.ToProblem(result.Error.ToStatusCode());
            });
               
        }
    }
}
