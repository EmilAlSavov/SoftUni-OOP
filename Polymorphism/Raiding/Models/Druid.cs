using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    internal class Druid : BaseHero
    {
        public Druid(string Name) : base(Name)
        {
            this.Power = 80;
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{this.GetType().Name} - {Name} healed for {Power}");
        }
    }
}
