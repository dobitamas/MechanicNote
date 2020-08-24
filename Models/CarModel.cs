using MechanicNote.Enums;

namespace MechanicNote.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public TypeEnum Type { get; set; }

        public string Code { get; set; }

        public CarModel(int id, string make, string model, int year, TypeEnum type, string code)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Type = type;
            Code = code;
        }

        public override bool Equals(object obj)
        {
            return obj is CarModel carModel &&
                   Id == carModel.Id;
        }
    }
}