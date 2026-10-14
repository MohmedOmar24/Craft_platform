using System.ComponentModel.DataAnnotations;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Create
{
    public record CreateCategoriesRequest(string Name,  string Description);
    
} 
