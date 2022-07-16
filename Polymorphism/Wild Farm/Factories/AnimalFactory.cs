using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Animals;

namespace Wild_Farm.Factories
{
    internal class AnimalFactory
    {
        public Animal CreateAnimal(string type, string name, double weight, string livingRegion, string breed)
        {
            Feline feline;
            if (type == "Cat")
            {
                return feline = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                return feline = new Tiger(name, weight, livingRegion, breed);
            }
            return null;
        }

        public Animal CreateAnimal(string type, string name, double wight, double wingSize)
        {
            Bird bird;

            if (type == "Owl")
            {
                return bird = new Owl(name, wight, wingSize);
            }
            else if (type == "Hen")
            {
                return bird = new Hen(name, wight, wingSize);
            }

            return null;
        }

        public Animal CreateAnimal(string type, string name, double weight, string livingREgion)
        {
            Mammal mammal;

            if (type == "Dog")
            {
                return mammal = new Dog(name, weight, livingREgion);
            } else if (type == "Mouse")
            {
                return mammal = new Mouse(name, weight, livingREgion);
            }
            return null;
        }
    }
}
