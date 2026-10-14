
using CraftPlatform.Inventory.Shared.Abstraction;

namespace CraftPlatform.Inventory.Services.Errors
{
    public static class ProductErrors
    {
        public static readonly Error ProductNotFound = 
            new Error("Product.NotFound", "There is no product with the specified ID.");
        public static readonly Error ProductCategoryNotFound = 
            new Error("Product.CategoryNotFound", "The product category is not exist");
        public static readonly Error ProductInventoryNotFound =
           new Error("Product.InventoryNotFound", "The product inventory is not exist");


    }
}
