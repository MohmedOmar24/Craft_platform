namespace CraftPlatform.Inventory.Api.EndPoints.Inventories.Read
{
    public record ReadInventoriesResponse
    (
         Guid InventoryId,
        int Quantity,
        int ReorderLevel,
        string Location
    );
}
