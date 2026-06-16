using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Update
{
    public record CategoriesUpdateRequest
    (
        [FromRoute]
        Guid Id ,
        [FromBody]
        Body Body
    );
    public record Body(
        [Required]
        string Name,
        [Required]
        string Description
    );
    
}
