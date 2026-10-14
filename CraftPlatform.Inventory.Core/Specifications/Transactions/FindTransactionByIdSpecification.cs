
using Ardalis.Specification;
using CraftPlatform.Inventory.Core.Entities;

namespace CraftPlatform.Inventory.Core.Specifications.Transactions
{
    public class FindTransactionByIdSpecification:Specification<Transaction>
    {
        public FindTransactionByIdSpecification(Guid transactionId) 
                    => Query.Where(t => t.TransactionId == transactionId);
        
    }
}
