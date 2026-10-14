using CraftPlatform.Inventory.Core.Entities;
using Ardalis.Specification;

namespace CraftPlatform.Inventory.Core.Specifications.Products
{
    public class FindProductsSpecification:Specification<Product>
    {
        public FindProductsSpecification()
        {
            Query.Where(product => product.Id != 0);
        }   
    }
}
