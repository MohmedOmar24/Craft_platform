using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Inventories;
using CraftPlatform.Inventory.Shared.Contracts.Transactions;

namespace CraftPlatform.Inventory.Api.EndPoints.Transactions.Read
{
    public  static class Transactions
    {
        public static void MapTransactionsReadEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapGet(TransactionRoutes.BaseUrl, async (InventoryFactory<TransactionsOperationsContract, TransactionContract> factory)
                =>
            {
                var servic= factory.Build(nameof(Transaction));
                var result =await servic.Read();

               return result.Succeeded?
                Results.Ok(result.Value.Select(t=>new ReadTransactionsResponse(t.TransactionId, t.EmployeeId,
                                                                               t.TransactionDate, t.Quantity,
                                                                               t.TransactionType, t.Notes,
                                                                               t.CreatedBy, t.UpdatedBy,
                                                                               t.CreatedOn, t.UpdatedOn )).ToList()) 
                :result.ToProblem(result.Error.ToStatusCode());

            });
        }
    }
}
