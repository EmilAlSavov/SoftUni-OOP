using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Models.Animals
{
    internal abstract class Animal
    {

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        protected abstract double Fat { get;}

        protected abstract List<Type> TypeFoods { get;}

        public void Eat(Food food)
        {
            if (TypeFoods.Any(x => x == food.GetType()))
            {
                FoodEaten += food.Quantity;
                Weight += Fat * food.Quantity;  
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public abstract void ProduceSound();
    }
}
