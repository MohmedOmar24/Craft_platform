using CraftPlatform.Inventory.Shared.Contracts.Categories;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Create
{
    public static class CategoriesMapping
    {
        public static CategoriesOperationsContract ToCategoriesOperationsContract(this CreateCategoriesRequest request)
                => new (request.Name, request.Description);
        
    }
}
