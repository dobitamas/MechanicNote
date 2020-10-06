using MechanicNote.Enums;
using System.Collections.Generic;

namespace MechanicNote.ViewModels
{
    public class CreateCarViewModel
    {
        public CreateCarViewModel(int id, string make, string model, int year, List<TypeEnum> types, TypeEnum type, string code)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Types = types;
            Type = type;
            Code = code;
        }

        public CreateCarViewModel()
        {
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public List<TypeEnum> Types { get; set; }

        public TypeEnum Type { get; set; }
        public string Code { get; set; }
    }
}