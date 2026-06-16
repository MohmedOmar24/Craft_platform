using CraftPlatform.Inventory.Shared.Abstraction;
using CraftPlatform.Inventory.Shared.Contracts.Categories;

namespace CraftPlatform.Inventory.Core.Interfaces
{
    public interface ICategoriesService
    {
        Task<Result<CategoriesOperationsContract>> CreateCategory(CategoriesOperationsContract categoriesOperationsContract);
        Task<Result> UpdateCategory(Guid categoryId,CategoriesOperationsContract categoriesOperationsContract);
        Task<Result> DeleteCategory(Guid categoryId);
        Task<Result<CategoriesContract>> ReadCategoryById(Guid categoryId);
        Task<Result<IEnumerable<CategoriesContract>>> ReadCategories();
    }
}
