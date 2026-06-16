
using CraftPlatform.Inventory.Core.Specifications;

namespace CraftPlatform.Inventory.Services.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> ListAsync(BaseSpecification<T> specification, CancellationToken cancellationToken = default);
        Task<T?> FirstOrDefaultAsync(BaseSpecification<T> specification, CancellationToken cancellationToken = default);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}
