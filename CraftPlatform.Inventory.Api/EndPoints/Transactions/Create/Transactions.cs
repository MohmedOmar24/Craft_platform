using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Transactions;

namespace CraftPlatform.Inventory.Api.EndPoints.Transactions.Create
{
    public static class Transactions
    {
        public static void MapTransactionsCreateEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapPost(TransactionRoutes.BaseUrl, async (CreateTransactionRequest request, InventoryFactory<TransactionsOperationsContract, TransactionContract> factory) =>
            {
                var service = factory.Build(nameof(Transaction));
                var contract = new TransactionsOperationsContract
                (request.EmployeeId,request.Quantity,request.TransactionDate,request.TransactionType,request.Notes);
                
                var result = await service.Create(contract);


                return result.Succeeded ?
                Results.Ok(new CreateTransactionResponse(result.Value.TransactionId)) :
                result.ToProblem(result.Error.ToStatusCode());
            });    
        }
    }
}
