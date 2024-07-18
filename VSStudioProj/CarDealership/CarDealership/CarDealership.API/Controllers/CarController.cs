using CarDealership.API.Data;
using CarDealership.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly DataContext _context;

        public CarController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarsEntity>>> GetAllCars()
        {
            var cars = await _context.CarsEntities.ToListAsync(); 
            
            return Ok(cars);
        }

        [HttpGet("{VIN}")]
        public async Task<ActionResult<List<CarsEntity>>> GetCar(int VIN)
        {
            var car = await _context.CarsEntities.FindAsync(VIN);
            if (car is null)
                return NotFound("Car not found");

            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<List<CarsEntity>>> AddCar(CarsEntity car)
        {
            _context.CarsEntities.Add(car);
            await _context.SaveChangesAsync();

            return Ok(await GetAllCars());
        }
    }
}
