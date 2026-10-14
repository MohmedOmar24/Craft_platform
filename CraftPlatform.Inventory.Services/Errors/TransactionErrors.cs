using CraftPlatform.Inventory.Shared.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftPlatform.Inventory.Services.Errors
{
    public static class TransactionErrors
    {
        public static readonly Error ContractCannotBeNull =
         new Error("Transaction.ContractCannotBeNull", "Contract cannot be null");
        public static readonly Error TransactionNotFound =
         new Error("Transaction.TransactionNotFound", "Transaction not found");
    }
}
