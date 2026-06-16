using CraftPlatform.Inventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftPlatform.Inventory.Core.Specifications.Products
{
    public class FindProductByIdSpecification(Guid productId)
         : BaseSpecification<Product>(product => product.ProductId == productId)
    {
    }
}
