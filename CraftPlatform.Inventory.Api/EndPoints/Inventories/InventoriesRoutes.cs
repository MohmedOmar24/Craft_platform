namespace CraftPlatform.Inventory.Api.EndPoints.Inventories
{
    public static class InventoriesRoutes
    {
        public const string BaseUrl  = "/inventories";
        public const string ReadById = BaseUrl+"/{inventoryId}";
        public const string Read = BaseUrl;
        public const string Create = BaseUrl;
        public const string Update = BaseUrl + "/{inventoryId}";
        public const string Delete = BaseUrl + "/{inventoryId}";
    }
}
