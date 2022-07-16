using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Models.Animals
{
    internal class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override double Fat => 1;

        protected override List<Type> TypeFoods => new List<Type>() { typeof(Meat)};

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
