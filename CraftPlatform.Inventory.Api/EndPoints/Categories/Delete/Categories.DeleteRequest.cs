using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Delete
{
    public record CategoriesDeleteRequest
            ([FromRoute] Guid categoryId);
}
