using CraftPlatform.Inventory.Core.Entities;

namespace CraftPlatform.Inventory.Core.Specifications.Products
{
    public class FindSingleProductByCategoryId(Guid categoryId, Guid productId)
        : BaseSpecification<Product>(product => product.CategoryId == categoryId && product.ProductId == productId)
    {
    }
}
