using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Foods;

namespace Wild_Farm.Factories
{
    internal class FoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            Food food;
            if (type == "Fruit")
            {
                return food = new Fruit(quantity);
            } else if (type == "Meat")
            {
                return food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                return food = new Seeds(quantity);
            }
            else if (type == "Vegetable")
            {
                return food = new Vegetable(quantity);
            }

            return null;
        }
    }
}
