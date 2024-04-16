using System.Collections.ObjectModel;

namespace AnimalShelter
{
    public class Animal
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double Weight { get; set; }
        public String Color { get; set; }
        public String Category { get; set; }
        public Collection<MedicalRecord> MedicalRecords { get; set; }
    }
    
}