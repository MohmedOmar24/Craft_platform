namespace CraftPlatform.Inventory.Shared.Contracts.Products
{
    public record ProductsOperationsContract
    (
        Guid ProductId,
        Guid CategoryId,
        Guid InventoryId,
        string Name,
        string Description,
        decimal UnitPrice,
        float Width,
        float Weight ,
        float Length,
        float Height,
        decimal TaxCost,
        decimal ProfitPerUnit,
        decimal ProductionCost 
    );
}
