namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Create
{
    public record CreateCategoriesResponse
    (
        Guid Id,
        string Name,
        string Description
    );
}
