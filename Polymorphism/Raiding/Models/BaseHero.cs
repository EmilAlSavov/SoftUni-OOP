using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    internal abstract class BaseHero
    {
        public BaseHero(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; set; }

        public int Power { get; set; }

        abstract public void CastAbility();
    }
}
