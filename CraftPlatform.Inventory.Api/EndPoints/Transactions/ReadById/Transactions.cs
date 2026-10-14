using CraftPlatform.Inventory.Api.EndPoints.Transactions.Read;
using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Transactions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.EndPoints.Transactions.ReadById
{
    public static class Transactions
    {
        public static void MapTransactionsReadByIdEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet(TransactionRoutes.ReadById, async ([FromRoute] Guid transactionId, InventoryFactory<TransactionsOperationsContract, TransactionContract> factory) =>
            {
                var servic = factory.Build(nameof(Transaction));
                var result = await servic.ReadById(transactionId);

                return result.Succeeded ?
                Results.Ok(new ReadTransactionsResponse(
                                                        result.Value.TransactionId, result.Value.EmployeeId,
                                                        result.Value.TransactionDate, result.Value.Quantity,
                                                        result.Value.TransactionType, result.Value.Notes,
                                                        result.Value.CreatedBy, result.Value.UpdatedBy,
                                                        result.Value.CreatedOn, result.Value.UpdatedOn))
                : result.ToProblem(result.Error.ToStatusCode());
            });
        }
    }
}
