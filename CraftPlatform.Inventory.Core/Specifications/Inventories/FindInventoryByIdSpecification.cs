
using Ardalis.Specification;

namespace CraftPlatform.Inventory.Core.Specifications.Inventories
{
    public class FindInventoryByIdSpecification:Specification<CraftPlatform.Inventory.Core.Entities.Inventory>
    {
        public FindInventoryByIdSpecification(Guid inventoryId)
        => Query.Where(inventory => inventory.InvenoryId == inventoryId);
        
    }
}
