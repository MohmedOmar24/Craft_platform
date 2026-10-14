using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CraftPlatform.Inventory.Api.EndPoints.Inventories.Update
{
   
        public record UpdateInventoriesRequest
        (
        [FromRoute]
        Guid inventoryId,
        [FromBody]
        IBody Body
        );
        public record IBody(
            [Required] int Quantity,
            [Required] int ReorderLevel,
            [Required] string Location
        );

    
}
