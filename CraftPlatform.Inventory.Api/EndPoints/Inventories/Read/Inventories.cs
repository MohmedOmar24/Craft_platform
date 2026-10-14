using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Inventories;

namespace CraftPlatform.Inventory.Api.EndPoints.Inventories.Read
{ 
    public static class Inventories
    {
        public static void MapInventoriesReadEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet(InventoriesRoutes.Read, async (InventoryFactory<InventoryOperationsContract, InventoryContract> inventoryFactory) =>
            {
                var service = inventoryFactory.Build(nameof(Inventory));
                var result = await service.Read();
                return result.Succeeded
                ? Results.Ok(result.Value.Select(inventory => new ReadInventoriesResponse(
                    InventoryId: inventory.InvenoryId,
                    Quantity: inventory.Quantity,
                    ReorderLevel: inventory.ReorderLevel,
                    Location: inventory.Location
                )).ToList())
                : result.ToProblem(result.Error.ToStatusCode());
            });
        }
    }
}
