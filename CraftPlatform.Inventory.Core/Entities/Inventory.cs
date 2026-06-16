

namespace CraftPlatform.Inventory.Core.Entities
{
    public class Inventory : BaseEntity
    {
        public Guid InvenoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public string Location { get; set; }= string.Empty;
        public DateTime LastUpdated { get; set; }


        public ICollection<Product> Products { get; set; } = [];

    }
}
