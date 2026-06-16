using CraftPlatform.Inventory.Shared.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CraftPlatform.Inventory.Api.Extensions
{
    public static class ResultExtensions
    {
        public static IResult ToProblem(this Result result,int statusCode)
        {
            if (result.Succeeded)
                throw new InvalidOperationException("Cannot convert success result to a problem");

            var problem=Results.Problem(statusCode: statusCode);
            var problemDetails = problem.GetType().GetProperty(nameof(ProblemDetails))!.GetValue(problem) as ProblemDetails;
            problemDetails!.Extensions= new Dictionary<string, object?>
            {
                {
                    "errors",new[] { result.Error }
                }
            };
            return Results.Problem(statusCode: statusCode, detail: problemDetails.Detail, title: problemDetails.Title, type: problemDetails.Type, instance: problemDetails.Instance);
           
            

        }
    }
}
