
using Ardalis.Specification;
using CraftPlatform.Inventory.Core.Entities;

namespace CraftPlatform.Inventory.Core.Specifications.Inventories
{
    public class FindInventoriesSpecification:Specification<CraftPlatform.Inventory.Core.Entities.Inventory>
    {
        public FindInventoriesSpecification()
        {
            Query.Where(inventory => inventory.Id != 0);
        }
    }
}
