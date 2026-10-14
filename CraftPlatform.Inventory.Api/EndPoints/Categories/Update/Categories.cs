using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Services.Factories;
using CraftPlatform.Inventory.Shared.Contracts.Categories;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Update
{
    public static class Categories
    {
        public static void MapCategoriesUpdateEndpoint(this IEndpointRouteBuilder app)
        {
            _ = app.MapPut(CategoriesRoutes.Update, async (UpdateCategoriesRequest request, InventoryFactory<CategoriesOperationsContract, CategoriesContract> factory) =>
            {

                var oData = new CategoriesOperationsContract (request.Body.Name,  request.Body.Description );
                var service = factory.Build(nameof(Category));
                var result = await service.Update(request.categoryId, oData);
               
                return result.Succeeded?
                       Results.Ok()
                       : result.ToProblem(result.Error.ToStatusCode());
            });
        }
}}
