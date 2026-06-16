

namespace CraftPlatform.Inventory.Core.Entities
{
    public class Order:BaseEntity
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public int Status { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime RecivedDate { get; set; }
        public int OrderType { get;  set; }
        public Guid SupplierId { get; set; }


        public ICollection<OrderDetail> OrderDetails { get; set; } = [];

    }
}
