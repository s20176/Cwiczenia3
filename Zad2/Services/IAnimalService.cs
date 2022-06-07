using System.Collections.Generic;
using Zad2.Model;

namespace Zad2.Services
{
    public interface IAnimalService
    {
        public List<Animal> getAnimals(string orderBy);
        public void addAnimal(Animal animal);
        public void updateAnimal(int idAnimal,Animal animal);
        public void deleteAnimal(int idAnimal);
        public Animal getAnimal(int idAnimal);
    }
}
