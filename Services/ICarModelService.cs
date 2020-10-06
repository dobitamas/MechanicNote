using MechanicNote.Enums;
using MechanicNote.Models;
using MechanicNote.ViewModels;
using Microsoft.CodeAnalysis.Differencing;
using System.Collections.Generic;

namespace MechanicNote.Services
{
    public interface ICarModelService
    {
        void AddCar(CarModel car);

        void DeleteCar(int id);

        CarModel GetCarById(int id);

        List<CarModel> GetCars();

        List<CarModel> Cars { get; set; }

        List<TypeEnum> GetTypes();

        CarModel GetCarByCode(string code);

        void EditCar(CarModel model);

        CarModel ConvertViewModelToModel(CreateCarViewModel carModel);

        CreateCarViewModel ConvertModelToViewModel(CarModel model);

        CarModel ConvertEditModelToModel(EditCarViewModel carModel);

        EditCarViewModel ConvertEditModelToViewModel(CarModel model);
    }
}