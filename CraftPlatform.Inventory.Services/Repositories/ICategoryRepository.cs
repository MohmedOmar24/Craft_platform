using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Core.Specifications;

namespace CraftPlatform.Inventory.Services.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category,CancellationToken cancellationToken = default);
        Task<Category?> FindBySpecificationAsync(BaseSpecification<Category> specification, CancellationToken cancellationToken = default);
       // Task<IEnumerable<Category>> FindBySpecificationAsync(BaseSpecification<Category> specification, CancellationToken cancellationToken = default);

        Task DeleteAsync (Category category, CancellationToken cancellationToken = default);

    }
}
