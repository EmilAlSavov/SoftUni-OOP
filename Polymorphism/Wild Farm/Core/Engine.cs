using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Factories;
using Wild_Farm.Models.Animals;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Core
{
    internal class Engine
    {
        public void Start()
        {
            AnimalFactory animalFactory = new AnimalFactory();
            FoodFactory foodFactory = new FoodFactory();

            List<Animal> animals = new List<Animal>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                Animal animal = null;
                Food food = null;

                string[] animalInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                if (animalInfo.Length == 4)
                {
                    string livingRegion = animalInfo[3];

                    if (int.TryParse(livingRegion, out int wingsize))
                    {
                         animal = animalFactory.CreateAnimal(type, name, weight, wingsize);
                    }
                    else
                    {
                         animal = animalFactory.CreateAnimal(type, name, weight, livingRegion);
                    }
                }
                else if (animalInfo.Length == 5)
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animal = animalFactory.CreateAnimal(type, name, weight, livingRegion, breed);
                }

                string[] foodInfo = Console.ReadLine().Split();

                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                food = foodFactory.CreateFood(foodType, quantity);

                animal.ProduceSound();

                animal.Eat(food);

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
