using MechanicNote.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MechanicNote.Services
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CarContext(
                serviceProvider.GetRequiredService<DbContextOptions<CarContext>>()))
            {
                if(context.CarModels.Any())
                {
                    return;
                }

                context.CarModels.AddRange(
                    new CarModel(1, "ALFA", "Giulia", 2019, Enums.TypeEnum.SEDAN, "alfa"),
                    new CarModel(2, "BMW", "M3", 2010, Enums.TypeEnum.SEDAN, "bmw"));
                context.SaveChanges();
            }
        }
    }
}
