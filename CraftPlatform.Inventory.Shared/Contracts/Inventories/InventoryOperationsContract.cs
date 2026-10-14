
namespace CraftPlatform.Inventory.Shared.Contracts.Inventories
{
    public record InventoryOperationsContract
    (
       int Quantity,
       int ReorderLevel,
       string Location
    );


}
