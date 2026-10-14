using CraftPlatform.Inventory.Core.Entities;
using Ardalis.Specification;
namespace CraftPlatform.Inventory.Core.Specifications.Categories
{
    public sealed class FindCategoryByIdSpecification
        : Specification <Category>
    {
        public FindCategoryByIdSpecification(Guid categoryId)
        {
            Query.Where(category => category.CategoryId == categoryId);
        }
    }
}
