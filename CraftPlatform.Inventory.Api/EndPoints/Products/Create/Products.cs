using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Products;

namespace CraftPlatform.Inventory.Api.EndPoints.Products.Create
{
    public static class Products
    {
        public static void MapProductsCreateEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapPost(ProductsRoutes.BaseUrl, async (CreateProductsRequest request, InventoryFactory<ProductsOperationsContract, ProductsContract> factory) =>
            {
                var service = factory.Build(nameof(Product));
                var result = await service.Create(
                    new ProductsOperationsContract(Guid.NewGuid(), request.CategoryId, request.InventoryId,
                                                   request.Name, request.Description, request.UnitPrice,
                                                   request.Width, request.Weight, request.Length,
                                                   request.Height, request.TaxCost,
                                                   request.ProfitPerUnit, request.ProductionCost)
                    );
                return result.Succeeded ? 
                Results.Ok(new CreateProductsResponse(result.Value.ProductId) ):
                result.ToProblem(result.Error.ToStatusCode());
            });
          
        }
    }
}
