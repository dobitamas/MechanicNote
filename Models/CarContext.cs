using Microsoft.EntityFrameworkCore;

namespace MechanicNote.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        private void Seed()
        {
            CarModels.Add(new CarModel(1, "ALFA", "Giulia", 2019, Enums.TypeEnum.SEDAN, "alfa"));
            CarModels.Add(new CarModel(2, "BMW", "M3", 2010, Enums.TypeEnum.SEDAN, "bmw"));
            CarModels.Add(new CarModel(3, "AUDI", "RS4", 2015, Enums.TypeEnum.SEDAN, "audi"));
            CarModels.Add(new CarModel(4, "SKODA", "OCTAVIA", 2020, Enums.TypeEnum.SEDAN, "skoda"));
        }

        public DbSet<CarModel> CarModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>()
                .HasNoKey();
        }
    }
}