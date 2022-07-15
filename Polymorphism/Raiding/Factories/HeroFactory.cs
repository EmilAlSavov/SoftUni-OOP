using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raiding.Models;

namespace Raiding.Factories
{
    internal class HeroFactory
    {
        public BaseHero CreateHero(string type, string name)
        {
            BaseHero hero;

            if (type == "Druid")
            {
                hero = new Druid(name);
            } else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                Console.WriteLine("Invalid hero!");
                return null;
            }
            return hero;
        }
    }
}
