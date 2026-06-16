
using CraftPlatform.Inventory.Shared.Abstraction;

namespace CraftPlatform.Inventory.Services.Errors
{
    public static class ProductErrors
    {
        public static readonly Error ProductNotFound = new Error("Product.NotFound", "There is no product with the specified ID.");
    }
}
