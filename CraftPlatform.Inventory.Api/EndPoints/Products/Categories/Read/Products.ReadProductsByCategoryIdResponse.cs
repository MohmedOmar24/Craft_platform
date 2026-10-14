using CraftPlatform.Inventory.Api.EndPoints.Products.Read;
namespace CraftPlatform.Inventory.Api.EndPoints.Products.Categories.Read
{
    public record ReadProductsByCategoryIdResponse
    (
        Guid ProductId,
        string Name,
        string Description,
        decimal Price,
        int Quantity,
        Guid CategoryId,
        Guid CreatedBy,
        Guid UpdatedBy,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
        
        
        
    
}
