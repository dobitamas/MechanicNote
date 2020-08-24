using MechanicNote.Interfaces;
using MechanicNote.Models;
using MechanicNote.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MechanicNote
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<CarContext>(opt => opt.UseInMemoryDatabase(databaseName: "CarList").EnableSensitiveDataLogging());
            services.AddSingleton<ICarModelService, CarModelService>();
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            //Seed(serviceProvider.GetRequiredService<CarContext>());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /*
        public static void Seed(CarContext context)
        {
            foreach (var entity in context.CarModels)
            {
                context.CarModels.Remove(entity);
                context.SaveChanges();
            }
                context.AddRange
                    (
                        new CarModel {Id = 1, Make = "Ford", Model = "Focus", Year = 2000, Type = Enums.TypeEnum.SEDAN,Code = "ford"},
                        new CarModel {Id = 2, Make = "Alfa", Model = "Giulia", Year = 2019, Type = Enums.TypeEnum.SEDAN,Code = "alfa"},
                        new CarModel {Id = 3, Make = "BWM", Model = "M3", Year = 2018, Type = Enums.TypeEnum.SEDAN, Code = "bmw"},
                        new CarModel {Id = 4, Make = "AUDI", Model = "RS4", Year = 219, Type = Enums.TypeEnum.SEDAN, Code = "audi"}
                    );

        context.SaveChanges();
        }
        */
    }
}