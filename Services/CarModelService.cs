using MechanicNote.Models;
using MechanicNote.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicNote.Interfaces
{
    public class CarModelService : ICarModelService
    {
        public DbSet<CarModel> Cars { get; set; }

        public void AddCar(CarModel car)
        {
            Cars.Add(car);
        }

        public void DeleteCar(CarModel car)
        {
            Cars.Remove(car);
        }

        public Task<CarModel> GetCarById(int id)
        {
            return Task.Run(() =>
            {
                foreach (var item in Cars)
                {
                    if (item.Id == id)
                    {
                        return item;
                    }
                }

                return null;
            });
        }

        public async Task<List<CarModel>> GetCars()
        {
            if(await Cars.ToListAsync() != null)
            {
                return await Cars.ToListAsync();
            } else
            {
                return new List<CarModel>();
            }
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