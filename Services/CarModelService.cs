using MechanicNote.Enums;
using MechanicNote.Models;
using MechanicNote.Services;
using MechanicNote.ViewModels;
using System.Collections.Generic;

namespace MechanicNote.Interfaces
{
    public class CarModelService : ICarModelService
    {
        public List<CarModel> Cars { get; set; }

        public CarModelService()
        {
            Cars = Seed();
        }

        public void AddCar(CarModel car)
        {
            Cars.Add(car);
        }

        public void DeleteCar(int id)
        {
            CarModel car = GetCarById(id);
            Cars.Remove(car);
        }

        public CarModel GetCarById(int id)
        {
            foreach (var item in Cars)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<CarModel> GetCars()
        {
            return Cars;
        }

        private List<CarModel> Seed()
        {
            List<CarModel> CarModels = new List<CarModel>
            {
                new CarModel("ALFA", "Giulia", 2019, TypeEnum.SEDAN, "alfa"),
                new CarModel("BMW", "M3", 2010, TypeEnum.SEDAN, "bmw"),
                new CarModel("AUDI", "RS4", 2015, TypeEnum.SEDAN, "audi"),
                new CarModel("SKODA", "OCTAVIA", 2020, TypeEnum.SEDAN, "skoda")
            };

            return CarModels;
        }

        public List<TypeEnum> GetTypes()
        {
            List<TypeEnum> Types = new List<TypeEnum>();

            foreach (var item in Cars)
            {
                if (!Types.Contains(item.Type))
                {
                    Types.Add(item.Type);
                }
            }

            return Types;
        }

        public void EditCar(CarModel model)
        {
            DeleteCar(model.Id);
            AddCar(model);
        }

        public CarModel GetCarByCode(string code)
        {
            foreach (var item in Cars)
            {
                if (item.Code == code)
                {
                    return item;
                }
            }
            return null;
        }

        public CarModel ConvertViewModelToModel(CreateCarViewModel view)
        {
            return new CarModel(view.Make, view.Model, view.Year, view.Type, view.Code);
        }

        public CreateCarViewModel ConvertModelToViewModel(CarModel model)
        {
            return new CreateCarViewModel(model.Id, model.Make, model.Model, model.Year, GetTypes(), model.Type, model.Code);
        }

        public CarModel ConvertEditModelToModel(EditCarViewModel view)
        {
            return new CarModel(view.Make, view.Model, view.Year, view.Type, view.Code);
        }

        public EditCarViewModel ConvertEditModelToViewModel(CarModel model)
        {
            return new EditCarViewModel(model.Id, model.Make, model.Model, model.Year, GetTypes(), model.Type, model.Code);
        }
    }
}