namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Read
{
    public record ReadCategoriesResponse
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
