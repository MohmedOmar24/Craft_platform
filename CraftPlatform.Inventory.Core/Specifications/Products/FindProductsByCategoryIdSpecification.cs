using CraftPlatform.Inventory.Core.Entities;
using Ardalis.Specification;
namespace CraftPlatform.Inventory.Core.Specifications.Products
{
    public class FindProductsByCategoryIdSpecification:Specification<Product>
    {
        public FindProductsByCategoryIdSpecification(Guid categoryId)
        {
            Query.Where(product => product.CategoryId == categoryId)
                 .Include(product => product.Category);
        }   
    }
}
