namespace CraftPlatform.Inventory.Api.EndPoints.Transactions.Create
{
    public record CreateTransactionRequest
     (
        Guid EmployeeId,
        int Quantity,
        DateTime TransactionDate,
        int TransactionType,
        string Notes
        );
}
