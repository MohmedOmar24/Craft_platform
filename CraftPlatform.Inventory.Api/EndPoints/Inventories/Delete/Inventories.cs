using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Inventories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CraftPlatform.Inventory.Api.EndPoints.Inventories.Delete
{
    public static class Inventories
    {
        public static void MapInventoriesDeleteEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapDelete(InventoriesRoutes.Delete, async ([FromRoute]Guid inventoryId, InventoryFactory<InventoryOperationsContract, InventoryContract> factory) =>
            {
                var service =  factory.Build(nameof(Inventory.Core.Entities.Inventory));
                var result = await service.Delete(inventoryId);

                return result.Succeeded
                ? Results.Ok()
                : result.ToProblem(result.Error.ToStatusCode());
            });
        }
    }
}
