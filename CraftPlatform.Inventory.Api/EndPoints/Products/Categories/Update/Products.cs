using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Products;

namespace CraftPlatform.Inventory.Api.EndPoints.Products.Categories.Update
{
    public static class Products
    {
        public static void MapProductsUpdateCategoryEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPut(ProductsRoutes.UpdateCategoryId, async (UpdateProductsCategoryRequest request, InventoryFactory<ProductsOperationsContract,ProductsContract> factory) =>
            {
               var service =factory.Build(nameof(Product));
               var result = await service.UpdateParentId(request.ProductId, request.Product.CategoryId);

                return result.Succeeded
                    ? Results.Ok()
                    : result.ToProblem(result.Error.ToStatusCode());
            });
        }
    }
}
