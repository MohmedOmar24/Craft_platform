using CraftPlatform.Inventory.Shared.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftPlatform.Inventory.Services.Errors
{
    public static class CategoryErrors
    {
        public static readonly Error CategoryNotFound = new Error("Category.NotFound", "There is no category with the specified ID.");
    }
}
