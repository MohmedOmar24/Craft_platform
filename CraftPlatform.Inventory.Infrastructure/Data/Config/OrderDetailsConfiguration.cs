using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CraftPlatform.Inventory.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CraftPlatform.Inventory.Infrastructure.Data.Config
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(x => x.OrderDetailsId)
                 .ValueGeneratedOnAdd();

        }
    }
}