using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Models.Animals
{
    internal class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override double Fat => 0.10;

        protected override List<Type> TypeFoods => new List<Type>() { typeof(Vegetable), typeof(Fruit)};

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
