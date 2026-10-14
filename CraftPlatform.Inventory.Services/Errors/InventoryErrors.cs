
using CraftPlatform.Inventory.Shared.Abstraction;

namespace CraftPlatform.Inventory.Services.Errors
{
    public static class InventoryErrors
    {
        public static readonly Error ContractCannotBeNull =
          new Error("Inventory.ContractCannotBeNull", "Contract cannot be null");
        public static readonly Error InventoryNotFound =
            new Error("Inventory.NotFound", "There is no inventory with the specified ID.");

    }
}
