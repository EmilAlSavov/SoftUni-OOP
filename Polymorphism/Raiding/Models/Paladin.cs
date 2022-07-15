using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    internal class Paladin : BaseHero
    {
        public Paladin(string Name) : base(Name)
        {
            this.Power = 100;
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{this.GetType().Name} - {Name} healed for {Power}");
        }
    }
}
