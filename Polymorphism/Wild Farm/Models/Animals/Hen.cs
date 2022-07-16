using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Models.Animals
{
    internal class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override double Fat => 0.35;
        protected override List<Type> TypeFoods => new List<Type>() { typeof(Food)};

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
