using System;
using System.Collections.Generic;
using System.Text;

namespace CraftPlatform.Inventory.Shared.Contracts.Transactions
{
    public record TransactionContract
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
