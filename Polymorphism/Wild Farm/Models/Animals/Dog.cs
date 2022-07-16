using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Models.Animals
{
    internal class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override double Fat => 0.40;

        protected override List<Type> TypeFoods => new List<Type>() {  typeof(Meat)};

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
