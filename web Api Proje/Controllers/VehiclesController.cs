using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_Api_Proje.Services;

namespace web_Api_Proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("cars")]
        public IActionResult GetCarsByColor(string color)
        {
            var cars = _vehicleService.GetCarsByColor(color);
            return Ok(cars);
        }

        [HttpGet("buses")]
        public IActionResult GetBusesByColor(string color)
        {
            var buses = _vehicleService.GetBusesByColor(color);
            return Ok(buses);
        }

        [HttpGet("boats")]
        public IActionResult GetBoatsByColor(string color)
        {
            var boats = _vehicleService.GetBoatsByColor(color);
            return Ok(boats);
        }

        [HttpPost("toggle-headlights/{carId}")]
        public IActionResult ToggleHeadlights(int carId)
        {
            _vehicleService.ToggleHeadlights(carId);
            return Ok();
        }

        [HttpDelete("delete-car/{carId}")]
        public IActionResult DeleteCar(int carId)
        {
            _vehicleService.DeleteCar(carId);
            return Ok();
        }
    }
}

