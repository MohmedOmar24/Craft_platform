namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Read
{
    public record CategoriesReadResponse
    (
     string Name,
     string Description,
     Guid CreatedBy,
     Guid UpdatedBy,
     DateTime CreatedAt,
     DateTime UpdatedAt
        );
}
