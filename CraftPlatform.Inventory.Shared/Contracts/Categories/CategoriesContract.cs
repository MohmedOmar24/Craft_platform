namespace CraftPlatform.Inventory.Shared.Contracts.Categories
{
    public record CategoriesContract
    (
     Guid CategoryId,
     string Name,
     string Description,
     Guid CreatedBy,
     Guid UpdatedBy,
     DateTime CreatedAt,
     DateTime UpdatedAt
        );
} 
