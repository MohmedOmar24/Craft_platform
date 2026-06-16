
namespace CraftPlatform.Inventory.Core.Entities
{
    public class Category: BaseEntity
    {
        public Guid CategoryId { get; set; }= Guid.NewGuid();
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; }=string.Empty;


        public ICollection<Product> Products { get; set; } = [];
    }
}
