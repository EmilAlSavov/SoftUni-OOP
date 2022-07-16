using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Models.Animals
{
    internal class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override double Fat => 0.25;

        protected override List<Type> TypeFoods => new List<Type>() { typeof(Meat)};

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
