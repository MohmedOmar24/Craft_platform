using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using CraftPlatform.Inventory.Core.Specifications;
using CraftPlatform.Inventory.Infrastructure.Data;
using CraftPlatform.Inventory.Services.Repositories;
using Microsoft.EntityFrameworkCore;


namespace CraftPlatform.Inventory.Infrastructure.Repositories
{
    public class GenericRepository<T>(AppDbContext dbContext) : IGenericRepository<T> where T : class
    {
        public async Task<IEnumerable<T>> ListAsync(ISpecification<T> specification,
                                                    CancellationToken cancellationToken = default)
        {
            return await SpecificationEvaluator.Default
                                               .GetQuery(dbContext.Set<T>(), specification)
                                               .ToListAsync(cancellationToken);
        }

        public async Task<T?> FirstOrDefaultAsync(ISpecification<T> specification,
                                                 CancellationToken cancellationToken = default)
        {
            return await SpecificationEvaluator.Default
                                               .GetQuery(dbContext.Set<T>(), specification)
                                               .FirstOrDefaultAsync(cancellationToken);
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await dbContext.Set<T>().AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
