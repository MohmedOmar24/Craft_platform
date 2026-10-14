using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Transactions.Delete
{
    public static class Transactions
    {
        public static void MapTransactionsDeleteEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapDelete(TransactionRoutes.Delete, async ([FromRoute]Guid transactionId,InventoryFactory<TransactionsOperationsContract, TransactionContract> factory) =>
            {
                var service = factory.Build(nameof(Transaction));
                var result = await service.Delete(transactionId);
                return result.Succeeded ?
                Results.Ok() :
               result.ToProblem(result.Error.ToStatusCode());
            });
        }
    }
}
