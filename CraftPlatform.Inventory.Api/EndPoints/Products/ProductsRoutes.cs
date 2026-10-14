namespace CraftPlatform.Inventory.Api.EndPoints.Products
{
    public static class ProductsRoutes
    {
        public const string BaseUrl = "/products";
        public const string Delete = BaseUrl + "/{productId}";
        public const string ReadById = BaseUrl + "/{productId}";
        public const string Update   = BaseUrl + "/{productId}";
        
        public const string ReadByCategoryId = "/category/{categoryId}"+BaseUrl;
        public const string ReadSingleByCategoryId = "/category/{categoryId}" + ReadById;
        public const string UpdateCategoryId = "/category" + Update;
    }
}
