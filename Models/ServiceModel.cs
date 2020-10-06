namespace MechanicNote.Models
{
    public class ServiceModel
    {
        private string Name { get; }

        public override bool Equals(object obj)
        {
            return obj is ServiceModel service &&
                   Name == service.Name;
        }

#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
        public override int GetHashCode() => throw new System.NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.
    }
}