using CraftPlatform.Inventory.Api.EndPoints.Categories.Create;
using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Inventories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CraftPlatform.Inventory.Api.EndPoints.Inventories.Create
{
    public static class Inventories
    {
        public static void MapInventoriesCreateEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost(InventoriesRoutes.BaseUrl, async (CreateInventoriesRequest request, InventoryFactory<InventoryOperationsContract, InventoryContract> inventoryFactory) =>
            {
                var service = inventoryFactory.Build(nameof(CraftPlatform.Inventory.Core.Entities.Inventory));
                var inventoryOperationsContract = new InventoryOperationsContract
                (request.Quantity, request.ReorderLevel,request.Location);
               
                var result= await service.Create(inventoryOperationsContract);

                return result.Succeeded
                ?Results.Ok(new CreateInventoriesResponse(result.Value.InvenoryId))
                :result.ToProblem(result.Error.ToStatusCode());
            });
        }
    }
}
