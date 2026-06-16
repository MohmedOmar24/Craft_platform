using CraftPlatform.Inventory.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CraftPlatform.Inventory.Infrastructure.Data.Config
{
    internal class InventoryConfiguration:IEntityTypeConfiguration<Inventory.Core.Entities.Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory.Core.Entities.Inventory> builder)
        {
            builder.Property(x => x.InvenoryId)
                 .ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                 .HasMaxLength(50);
            builder.Property(x => x.Location)
                 .HasMaxLength(100);
        }
    }
}
