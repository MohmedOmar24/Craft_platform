
using Ardalis.Specification;
using CraftPlatform.Inventory.Core.Entities;

namespace CraftPlatform.Inventory.Core.Specifications.Transactions
{
    public class FindTransactionsSpecification : Specification<Transaction>
    {
        public FindTransactionsSpecification()
        {
            Query.Where(t => t.Id != 0);

        }
    }
}
