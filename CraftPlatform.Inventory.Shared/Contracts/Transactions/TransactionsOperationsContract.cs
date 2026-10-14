using System;
using System.Collections.Generic;
using System.Text;

namespace CraftPlatform.Inventory.Shared.Contracts.Transactions
{
    public record TransactionsOperationsContract
    (
        Guid EmployeeId,
        int Quantity,
        DateTime TransactionDate,
        int TransactionType,
        string Notes
    );
}
