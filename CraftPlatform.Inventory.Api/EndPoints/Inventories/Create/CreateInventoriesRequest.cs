namespace CraftPlatform.Inventory.Api.EndPoints.Inventories.Create
{
    public record CreateInventoriesRequest
    (
        int Quantity,
        int ReorderLevel,
        string Location
    );

}
