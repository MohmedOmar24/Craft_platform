using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Categories;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Create
{
    public static class Categories 
    {

        public static void MapCategoriesCreateEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapPost(CategoriesRoutes.BaseUrl, async ( CreateCategoriesRequest request,InventoryFactory<CategoriesOperationsContract, CategoriesContract> factory) =>
            {
                var service = factory.Build(nameof(Category));              
                var result = await service.Create(request.ToCategoriesOperationsContract());

                return result.Succeeded
                       ? Results.Ok()
                       : result.ToProblem(result.Error.ToStatusCode());
            });
        }

}}
