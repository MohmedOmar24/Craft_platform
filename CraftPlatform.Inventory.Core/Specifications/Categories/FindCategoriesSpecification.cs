using CraftPlatform.Inventory.Core.Entities;
using Ardalis.Specification;
namespace CraftPlatform.Inventory.Core.Specifications.Categories
{
    public sealed class FindCategoriesSpecification:Specification<Category>
    {
        public FindCategoriesSpecification()
        {
            Query.Where(category => category.Id != 0);
        }
    }
}
