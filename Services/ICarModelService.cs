using MechanicNote.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MechanicNote.Services
{
    public interface ICarModelService
    {
        Task<List<CarModel>> GetCars();

        Task<CarModel> GetCarById(int id);

        void AddCar(CarModel car);

        void DeleteCar(CarModel car);
    }
}