
namespace CraftPlatform.Inventory.Shared.Contracts.Inventories
{
    public record InventoryContract
        (
        Guid InvenoryId,
        int Quantity,
        int ReorderLevel,
        string Location
        );
    
        
    

}
