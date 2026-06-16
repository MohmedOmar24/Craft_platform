using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Shared.Contracts.Categories;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Update
{
    public static class Categories
    {
        public static void MapCategoriesUpdateEndpoint(this WebApplication app)
        {
            _ = app.MapPut(CategoriesRoutes.Update, async (CategoriesUpdateRequest request, ICategoriesService categoriesService) =>
            {

                var oData = new CategoriesOperationsContract (request.Body.Name,  request.Body.Description );
                var result = await categoriesService.UpdateCategory(request.Id, oData);
               
                return result.Succeeded?
                       Results.Ok()
                       : result.ToProblem(result.Error.ToStatusCode());
            });
        }
}}
