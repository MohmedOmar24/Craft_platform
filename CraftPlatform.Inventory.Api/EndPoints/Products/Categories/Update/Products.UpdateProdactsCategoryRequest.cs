using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Products.Categories.Update
{
    public record UpdateProductsCategoryRequest
    (
    [FromRoute]
     Guid ProductId,
    [FromBody]
     UpdateProduct Product
    );

    public record UpdateProduct
    (
      Guid CategoryId
    );
}

