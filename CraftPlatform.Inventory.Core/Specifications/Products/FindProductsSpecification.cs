using CraftPlatform.Inventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftPlatform.Inventory.Core.Specifications.Products
{
    public class FindProductsSpecification():BaseSpecification<Product>(Product => Product.Id != 0)
    {
    }
}
