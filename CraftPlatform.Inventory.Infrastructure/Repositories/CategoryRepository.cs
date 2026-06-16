using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Core.Specifications;
using CraftPlatform.Inventory.Infrastructure.Data;
using CraftPlatform.Inventory.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CraftPlatform.Inventory.Infrastructure.Repositories
{
    public class CategoryRepository(AppDbContext dbContext): ICategoryRepository
    {
        public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
        {
            await  dbContext.AddAsync(category, cancellationToken);
            await  dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Category?> FindBySpecificationAsync(BaseSpecification<Category> specification, CancellationToken cancellationToken = default)
        =>   await dbContext.Categories.Where(specification.Criteria).FirstOrDefaultAsync(cancellationToken);
       
        public async Task DeleteAsync(Category category, CancellationToken cancellationToken = default)
        {
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync(cancellationToken);
        }



        }
}
