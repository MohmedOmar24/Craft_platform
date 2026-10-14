using Ardalis.Specification;

namespace CraftPlatform.Inventory.Services.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}
