using DavidWebApi.Models.Repositories;
using DavidWebApi.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DavidWebApi.Filters.ActionFilters
{
    public class Car_ValidateCreateCarFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var car = context.ActionArguments["car"] as Car;

            if (car == null)
            {
                context.ModelState.AddModelError("Car", "Car object is null.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingCar = CarRepository.GetCarByProperties(car.Make, car.Model, car.Color);
                if (existingCar != null)
                {
                    context.ModelState.AddModelError("Car", "Car already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }




        }
    }
}
