using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CraftPlatform.Inventory.Api.EndPoints.Products.Update
{
    public record UpdateProductsRequest
    (
        [FromRoute]
        Guid productId,
        [FromBody]
        pBody Body
    );
    public record pBody(
        [Required]
        string Name,
        [Required]
        string Description
    );
}
