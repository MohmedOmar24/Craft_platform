using CraftPlatform.Inventory.Api.EndPoints.Categories.Create;
using CraftPlatform.Inventory.Api.EndPoints.Categories.Read;
using CraftPlatform.Inventory.Api.EndPoints.Categories.Delete;
using CraftPlatform.Inventory.Api.EndPoints.Categories.Update;
using CraftPlatform.Inventory.Api.EndPoints.Categories.ReadById;

using CraftPlatform.Inventory.Api.EndPoints.Products.Create;
using CraftPlatform.Inventory.Api.EndPoints.Products.Read;
using CraftPlatform.Inventory.Api.EndPoints.Products.Delete;
using CraftPlatform.Inventory.Api.EndPoints.Products.Update;
using CraftPlatform.Inventory.Api.EndPoints.Products.ReadById;
using CraftPlatform.Inventory.Api.EndPoints.Products.Categories.Read;
using CraftPlatform.Inventory.Api.EndPoints.Products.Categories.Update;
using CraftPlatform.Inventory.Api.EndPoints.Inventories.Create;
using CraftPlatform.Inventory.Api.EndPoints.Inventories.Read;
using CraftPlatform.Inventory.Api.EndPoints.Inventories.ReadById;
using CraftPlatform.Inventory.Api.EndPoints.Inventories.Update;
using CraftPlatform.Inventory.Api.EndPoints.Inventories.Delete;
using CraftPlatform.Inventory.Api.EndPoints.Transactions.Create;
using CraftPlatform.Inventory.Api.EndPoints.Transactions.Read;
using CraftPlatform.Inventory.Api.EndPoints.Transactions.ReadById;
using CraftPlatform.Inventory.Api.EndPoints.Transactions.Delete;





namespace CraftPlatform.Inventory.Api.Extensions
{
    public static class EndpointsMapping
    {

        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapCategoriesEndpoints();
            app.MapProductsEndpoints();
            app.MapInventoriesEndpoints();
            app.MapTransactionsEndpoints();
            return app;
        }
        private static IEndpointRouteBuilder MapCategoriesEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapCategoriesCreateEndPoint();
            app.MapCategoriesReadEndpoint();
            app.MapCategoriesReadByIdEndpoint();
            app.MapCategoriesUpdateEndpoint();
            app.MapCategoriesDeleteEndpoint();
            return app;
        }

        private static IEndpointRouteBuilder MapProductsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapProductsCreateEndPoint();
            app.MapProductsReadEndPoint();
            app.MapProductsReadByIdEndPoint();
            app.MapProductsUpdateEndPoint();
            app.MapProductsDeleteEndPoint();
            app.MapReadProductsByCategoryIdEndpoint();
            app.MapProductsUpdateCategoryEndpoint();
            return app;
        }
        private static IEndpointRouteBuilder MapInventoriesEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapInventoriesCreateEndpoint();
            app.MapInventoriesReadEndpoint();
            app.MapInventoriesReadByIdEndpoint();
            app.MapInventoriesUpdateEndpoint();
            app.MapInventoriesDeleteEndpoint();
            return app;
        }

        private static IEndpointRouteBuilder MapTransactionsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapTransactionsCreateEndPoint();
            app.MapTransactionsReadEndPoint();
            app.MapTransactionsReadByIdEndpoint();
            app.MapTransactionsDeleteEndpoint();
            return app;
        }
    }
}
