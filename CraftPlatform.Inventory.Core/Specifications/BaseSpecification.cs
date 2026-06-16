using System.Linq.Expressions;

namespace CraftPlatform.Inventory.Core.Specifications
{
   
    public abstract class BaseSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
    }
}
