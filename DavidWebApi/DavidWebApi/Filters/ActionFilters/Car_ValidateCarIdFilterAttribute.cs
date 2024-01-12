using DavidWebApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DavidWebApi.Filters.ActionFilters
{
    public class Car_ValidateCarIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var carId = context.ActionArguments["id"] as int?;
            if (carId.HasValue)
            {
                if (carId.Value <= 0)
                {
                    context.ModelState.AddModelError("CarId", "CarId is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!CarRepository.CarExists(carId.Value))
                {
                    context.ModelState.AddModelError("CarId", "Car doesn't exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
