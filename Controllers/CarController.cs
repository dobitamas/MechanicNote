using MechanicNote.Interfaces;
using MechanicNote.Models;
using MechanicNote.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicNote.Controllers
{
    [Route("/Car/")] 
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarContext _context;

        private readonly ICarModelService _service = new CarModelService();

        public CarController(CarContext context, ICarModelService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        [Route("/list")]
        public async Task<List<CarModel>> GetCars()
        {
             if(await _service.GetCars() != null)
             {
                return await _service.GetCars();
             }
             else
             {
                return new List<CarModel>();
             }
        }

        [HttpGet]
        [Route("/get-car")]
        public async Task<ActionResult<CarModel>> GetCarById(int id)
        {
            /*
            var carModel = await _service.GetCarById(id);
            if (carModel == null)
            {
                return NotFound();
            }
            return carModel;
            */
            System.Console.WriteLine("Beléptem");
            System.Console.WriteLine(_context.CarModels.Count());

            return null;
        }

        [HttpPut]
        public async Task<IActionResult> PutCarModel(CarModel car)
        {
            _context.Entry(car).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CarModel>> PostCarModel(CarModel car)
        {
            _context.CarModels.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        [HttpDelete]
        public async Task<ActionResult<CarModel>> DeleteCarModel(int id)
        {
            var carModel = await _context.CarModels.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }

            _context.CarModels.Remove(carModel);
            await _context.SaveChangesAsync();

            return carModel;
        }

        private bool CarModelExists(int id)
        {
            return _context.CarModels.Any(e => e.Id == id);
        }

        private List<CarModel> Seed()
        {
            List<CarModel> CarModels = new List<CarModel>();
            CarModels.Add(new CarModel(1, "ALFA", "Giulia", 2019, Enums.TypeEnum.SEDAN, "alfa"));
            CarModels.Add(new CarModel(2, "BMW", "M3", 2010, Enums.TypeEnum.SEDAN, "bmw"));
            CarModels.Add(new CarModel(3, "AUDI", "RS4", 2015, Enums.TypeEnum.SEDAN, "audi"));
            CarModels.Add(new CarModel(4, "SKODA", "OCTAVIA", 2020, Enums.TypeEnum.SEDAN, "skoda"));

            return CarModels;
        }
    }
}