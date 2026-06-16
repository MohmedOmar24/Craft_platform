

using CraftPlatform.Inventory.Api.Extensions;
using CraftPlatform.Inventory.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace CraftPlatform.Inventory.Api.EndPoints.Categories.Create
{
    public static class Categories
    {

        public static void MapCategoriesCreateEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapPost(CategoriesRoutes.BaseUrl, async ( CreateCategoriesRequest request, [FromServices] ICategoriesService categoriesService) =>
            {
                var result = await categoriesService.CreateCategory(request.ToCategoriesOperationsContract());

                return result.Succeeded
                       ? Results.Ok()
                       : result.ToProblem(result.Error.ToStatusCode());
            });
        }

}}
