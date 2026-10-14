using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Inventories.Update
{
    public static class Inventories
    {
        public static void MapInventoriesUpdateEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPut(InventoriesRoutes.Update, async (UpdateInventoriesRequest request, InventoryFactory<InventoryOperationsContract, InventoryContract> factory) =>
            {
                var service = factory.Build(nameof(Inventory.Core.Entities.Inventory));
                var result = await service.Update(request.inventoryId, new InventoryOperationsContract(
                    Quantity: request.Body.Quantity,
                    ReorderLevel: request.Body.ReorderLevel,
                    Location: request.Body.Location
                ));
                return result.Succeeded
                    ? Results.Ok()
                    : result.ToProblem(result.Error.ToStatusCode());
            })
            .WithName("UpdateInventory")
            .Produces<InventoryContract>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
          
        }
    }
}
