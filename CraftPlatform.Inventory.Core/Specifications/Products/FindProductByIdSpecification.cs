using CraftPlatform.Inventory.Core.Entities;
using Ardalis.Specification;

namespace CraftPlatform.Inventory.Core.Specifications.Products
{
    public class FindProductByIdSpecification
         : Specification<Product>
    {
        public FindProductByIdSpecification(Guid productId)
        {
            Query.Where(product =>product.ProductId == productId).Include(p=>p.Inventory);
        }
    }
}
