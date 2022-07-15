using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raiding.Factories;
using Raiding.Models;

namespace Raiding.Core
{
    internal class Engine
    {
        public void Start()
        {
            List<BaseHero> raid = new List<BaseHero>();
            int sum = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                HeroFactory factory = new HeroFactory();

                var hero = factory.CreateHero(type, name);

                if (hero == null)
                {
                    continue;
                }
                raid.Add(hero);
                sum += hero.Power;
            }

            int enemy = int.Parse(Console.ReadLine());

            foreach (var hero in raid)
            {
                hero.CastAbility();
            }

            if (sum >= enemy)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
