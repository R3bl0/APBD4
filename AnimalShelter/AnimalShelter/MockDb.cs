namespace AnimalShelter
{
    public interface IMockDb
    {
        public ICollection<Animal> GetAllAnimals();
        public Animal GetAnimal(int id);
        public bool AddAnimal(Animal animal);
        public Animal? RemoveAnimal(int id);
        
    }
    
    public class MockDb: IMockDb
    {
        private ICollection<Animal> _animals;

        public MockDb()
        {
            _animals = new List<Animal>{
                new Animal{
                    Id = 1, Name = "Burak", Color = "Brown", Weight = 2.5, Category = "Akita"
                },
                new Animal{
                    Id = 2, Name = "Pasztet", Color = "Black", Weight = 3.78, Category = "German Shepherd"
                },
                new Animal{
                    Id = 3, Name = "Orka", Color = "Black-White", Weight = 1.45, Category = "Chinese Imperial Chin"
                }
            };
        }

        public ICollection<Animal> GetAllAnimals()
        {
            return _animals;
        }

        public Animal GetAnimal(int id)
        {
            return _animals.FirstOrDefault(a => a.Id == id);
        }

        public bool AddAnimal(Animal animal)
        {
            _animals.Add(animal);
            return true;
        }

        public Animal? RemoveAnimal(int id)
        {
            var animalToDelete = _animals.FirstOrDefault(a => a.Id == id);
            if (animalToDelete is null)
            {
                return null;
            }
            _animals.Remove(animalToDelete);
            return animalToDelete;
        }
        
    }
}