namespace CraftPlatform.Inventory.Core.Entities
{
    public class Transaction:BaseEntity
    {
        public Guid TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }= string.Empty;
        public int TransactionType { get; set; } // 0 for incoming, 1 for outgoing

        public Guid EmployeeId { get; set; }
        public ICollection<Product> Products { get; set; } = [];
    }
}
