using DavidWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DavidWebApi.Filters.ActionFilters
{
    public class Car_ValidateUpdateCarFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var car = context.ActionArguments["car"] as Car;

            if (id.HasValue && car != null && id != car.CarId)
            {
                context.ModelState.AddModelError("CarId", "CarId is not the same as id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

        }
    }
}
