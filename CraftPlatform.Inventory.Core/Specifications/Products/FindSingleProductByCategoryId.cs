using CraftPlatform.Inventory.Core.Entities;
using Ardalis.Specification;


namespace CraftPlatform.Inventory.Core.Specifications.Products
{
    public class FindSingleProductByCategoryId:Specification<Product>
    {       public FindSingleProductByCategoryId(Guid categoryId, Guid productId) 
        {
            Query.Where(product => product.CategoryId == categoryId && product.ProductId == productId)
                 .Include(product => product.Category);
        }
    }
}
