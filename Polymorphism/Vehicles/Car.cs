using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    internal class Car : Vehicle
    {
        public Car(double fuelTank, double consumption, double tankCapacity) : base(fuelTank, consumption, tankCapacity)
        {
            Consumption += 0.9;
        }
    }
}
