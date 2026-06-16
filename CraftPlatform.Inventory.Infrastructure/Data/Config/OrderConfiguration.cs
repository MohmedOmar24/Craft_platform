using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CraftPlatform.Inventory.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CraftPlatform.Inventory.Infrastructure.Data.Config
{
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
         public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.OrderId)
                 .ValueGeneratedOnAdd();
           
        }
    }
}
