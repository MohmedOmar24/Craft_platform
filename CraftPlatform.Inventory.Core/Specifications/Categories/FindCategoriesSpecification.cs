using CraftPlatform.Inventory.Core.Entities;

namespace CraftPlatform.Inventory.Core.Specifications.Categories
{
    public sealed class FindCategoriesSpecification(): BaseSpecification<Category>
        (category => category.Id !=0)
    {
    }
}
