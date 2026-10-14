namespace CraftPlatform.Inventory.Api.EndPoints.Categories
{
    public static class CategoriesRoutes
    {
        public const string BaseUrl = "/categories";
        public const string Delete = BaseUrl + "/{categoryId}";
        public const string ReadById = BaseUrl + "/{categoryId}";
        public const string Update = BaseUrl + "/{categoryId}";
    }
}
