using DavidWebApi.Filters;
using DavidWebApi.Filters.ActionFilters;
using DavidWebApi.Filters.ExceptionFilters;
using DavidWebApi.Models;
using DavidWebApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DavidWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok (CarRepository.GetCars());
        }
        
        [HttpGet("{id}")]
        [Car_ValidateCarIdFilter]
        public IActionResult GetCarById(int id)
        {
      
            return Ok(CarRepository.GetCarById(id));
        }

        [HttpPost]
        [Car_ValidateCreateCarFilter]
        public IActionResult CreateCar([FromForm] Car car)
        {


            CarRepository.AddCar(car);

            return CreatedAtAction(nameof(GetCarById),
                new { id = car.CarId },
                car);
        }

        [HttpPut("{id}")]
        [Car_ValidateCarIdFilter]
        [Car_ValidateUpdateCarFilter]
        [Car_HandleUpdateExceptionsFilter]
        public IActionResult UpdateCar(int id, Car car)
        {
     
            CarRepository.UpdateCar(car);
        
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Car_ValidateCarIdFilter]
        public IActionResult DeleteCar(int id)
        {
            var car = CarRepository.GetCarById(id);
            CarRepository.DeleteCar(id);
            
            return Ok (car);
        }
    }
}
