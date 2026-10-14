using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Inventories;

namespace CraftPlatform.Inventory.Api.EndPoints.Inventories.ReadById
{
    public static class Inventories
    {
        public static void MapInventoriesReadByIdEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet(InventoriesRoutes.ReadById, async (Guid inventoryId,InventoryFactory<InventoryOperationsContract,InventoryContract> factory) =>
            {
                var service = factory.Build(nameof(Inventory.Core.Entities.Inventory));
                var result = await service.ReadById(inventoryId);

                return result.Succeeded
                    ? Results.Ok(new ReadInventoriesResponse(
                        InventoryId: result.Value.InvenoryId,
                        Quantity: result.Value.Quantity,
                        ReorderLevel: result.Value.ReorderLevel,
                        Location: result.Value.Location
                    ))
                    : result.ToProblem(result.Error.ToStatusCode());
            });
            
        }
    }
}
