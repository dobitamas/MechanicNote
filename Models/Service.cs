namespace MechanicNote.Models
{
    public class Service
    {
        private string Name { get; set; }
        private int Time { get; set; }
        private int Price { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Service service &&
                   Name == service.Name;
        }
    }
}