
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CraftPlatform.Inventory.Core.Entities;
namespace CraftPlatform.Inventory.Infrastructure.Data.Config
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id)
                 .ValueGeneratedOnAdd();
            builder.Property(x => x.CategoryId)
                 .IsRequired();
            builder.Property(x => x.Name)
                 .HasMaxLength(50);
            builder.Property(x => x.Description)
                 .HasMaxLength(200);
        }
    }
}
