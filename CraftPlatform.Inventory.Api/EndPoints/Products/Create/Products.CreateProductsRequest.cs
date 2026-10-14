namespace CraftPlatform.Inventory.Api.EndPoints.Products.Create
{
    public record CreateProductsRequest 
    (
        Guid CategoryId,
        Guid InventoryId,
        string Name,
        string Description,
        decimal UnitPrice,
        float Width,
        float Weight,
        float Length,
        float Height,
        decimal TaxCost,
        decimal ProfitPerUnit,
        decimal ProductionCost
    );
}
