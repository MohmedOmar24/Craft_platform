using CraftPlatform.Inventory.Services.Errors;
using CraftPlatform.Inventory.Shared.Abstraction;

namespace CraftPlatform.Inventory.Api.Extensions
{
    public static class ErrorMapping
    {
        public static int  ToStatusCode(this Error error) 
        {
            var s = CategoryErrors.CategoryNotFound.Code;
            return error.Code switch
            {
                 
                "Categories.NotFound" => StatusCodes.Status404NotFound,
               
                _ => 500
            };
}
    }
}
