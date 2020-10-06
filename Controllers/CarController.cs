using MechanicNote.Enums;
using MechanicNote.Models;
using MechanicNote.Services;
using MechanicNote.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MechanicNote.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        #region Private Fields
        private readonly ICarModelService _service;
        #endregion

        #region Constructor
        public CarController(ICarModelService service)
        {
            _service = service;
        }
        #endregion

        #region GetCar
        [HttpGet("/Car/GetCars")]
        public ActionResult GetCars()
        {
            var cars = _service.GetCars();
            return View(cars);
        }

        [HttpGet("ID/{id}", Name = "GetCar")]
        public CarModel GetCarById(int id)
        {
            return _service.GetCarById(id);
        }

        [HttpGet("/GetByCode/{code}")]
        public ActionResult GetCarByCode(string code)
        {
            var carModel = _service.GetCarByCode(code);
            if (carModel == null)
            {
                return View("Error");
            }
            return View("Details", carModel);
        }

        #endregion

        #region CreateCar
        [HttpGet("/Car/Create")]
        public ActionResult Create()
        {
            System.Console.WriteLine("Create hívódik");
            var model = new CreateCarViewModel
            {
                Types = _service.GetTypes()
            };

            return View(model);
        }

        [HttpPost(Name ="PostNewCar")]
        public ActionResult PostNewCar([FromForm]CreateCarViewModel CreateCarViewModel)
        {
            _service.AddCar(_service.ConvertViewModelToModel(CreateCarViewModel));

            return View("Index", _service.GetCars());
        }
        #endregion

        #region EditCar
        [HttpGet("/Car/Edit/{id}", Name = "Edit")]
        public ActionResult Edit(int id)
        {
            return View(_service.ConvertEditModelToViewModel(_service.GetCarById(id)));
        }

        [HttpPost(Name ="PostEditedCar")]
        public ActionResult PostEditedCar([FromForm]EditCarViewModel CarView)
        {
            _service.DeleteCar(CarView.Id);
            _service.AddCar(_service.ConvertEditModelToModel(CarView));

            return View("Index", _service.GetCars());
        }
        #endregion

        #region DeleteCar
        [HttpGet("Delete/{id}", Name = "Delete")]
        public RedirectToActionResult Delete(int id)
        {
            _service.DeleteCar(id);
            return RedirectToAction("/list");
        }
        #endregion

        
    }
}