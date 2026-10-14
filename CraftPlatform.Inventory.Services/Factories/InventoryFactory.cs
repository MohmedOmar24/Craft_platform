using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Services.CategoriesImplementations;
using CraftPlatform.Inventory.Services.InventoriesImplementations;
using CraftPlatform.Inventory.Services.ProductsImplementations;
using CraftPlatform.Inventory.Services.Repositories;

namespace CraftPlatform.Inventory.Services.Factories
{
    public class InventoryFactory<TRequest, TResponse> (IGenericRepository<Category> categoryRepository,
                                                        IGenericRepository<Product> productRepository,
                                                        IGenericRepository<CraftPlatform.Inventory.Core.Entities.Inventory> inventoryRepository,
                                                        IGenericRepository<Transaction> transactionRepository)
    {
        public IGenericServices<TRequest,TResponse> Build(string key)
        {
            return key switch
            {
                nameof(Category) => new CategoriesService<TRequest, TResponse>(categoryRepository),
                nameof(Product) => new ProductsServices<TRequest, TResponse>(productRepository, categoryRepository, inventoryRepository),
                nameof(CraftPlatform.Inventory.Core.Entities.Inventory) => new InventoriesService<TRequest, TResponse>(inventoryRepository),
                nameof(Transaction) => new TransactionsImplementations.TransactiosnService<TRequest, TResponse>(transactionRepository),
                _ => null!,
            };
        }
    }
}
