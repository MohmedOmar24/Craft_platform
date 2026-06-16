

namespace CraftPlatform.Inventory.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
       
    }
}
