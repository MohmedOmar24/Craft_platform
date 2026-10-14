namespace CraftPlatform.Inventory.Api.EndPoints.Inventories.ReadById
{
    public record ReadInventoriesResponse
    (
         Guid InventoryId,
        int Quantity,
        int ReorderLevel,
        string Location
    );
}
