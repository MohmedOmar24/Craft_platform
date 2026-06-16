using CraftPlatform.Inventory.Core.Entities;

namespace CraftPlatform.Inventory.Core.Specifications.Categories
{
    public sealed class FindCategoryByIdSpecification(Guid categoryId)
        : BaseSpecification<Category>(category => category.CategoryId == categoryId)
    {
    }
}
