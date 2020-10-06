using MechanicNote.Enums;

namespace MechanicNote.Models
{
    public class CarModel
    {
        private int lastId = 0;
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public TypeEnum Type { get; set; }

        public string Code { get; set; }

        public CarModel(string make, string model, int year, TypeEnum type, string code)
        {
            Id = CreateId();
            Make = make;
            Model = model;
            Year = year;
            Type = type;
            Code = code;
        }

        public int CreateId()
        {
            return lastId++;
        }
    }
}