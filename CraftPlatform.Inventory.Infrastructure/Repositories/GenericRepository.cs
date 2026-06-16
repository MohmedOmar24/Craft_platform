using CraftPlatform.Inventory.Core.Specifications;
using CraftPlatform.Inventory.Infrastructure.Data;
using CraftPlatform.Inventory.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftPlatform.Inventory.Infrastructure.Repositories
{
    public class GenericRepository<T>(AppDbContext dbContext) : IGenericRepository<T> where T : class
    {
        public async Task<IEnumerable<T>> ListAsync(BaseSpecification<T> specification,
                                                    CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>()
                .Where(specification.Criteria)
                .ToListAsync(cancellationToken);
        }

        public async Task<T?> FirstOrDefaultAsync(BaseSpecification<T> specification,
                                                 CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>()
                .Where(specification.Criteria)
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
