namespace CraftPlatform.Inventory.Api.EndPoints.Transactions.Read
{
    public record ReadTransactionsResponse
    (
         Guid TransactionId,
         Guid EmployeeId,
         DateTime TransactionDate,
         int Quantity,
         int TransactionType,
         string Notes,
         Guid CreatedBy,
         Guid UpdatedBy,
         DateTime CreatedOn,
         DateTime UpdatedOn 
    );
}
