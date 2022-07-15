using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    internal class Truck : Vehicle
    {
        public Truck(double fuelTank, double consumption, double tankCapacity) : base(fuelTank, consumption, tankCapacity)
        {
            Consumption += 1.6;
        }
        public override void Refuel(double liters)
        {
            if (FuelTank + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                liters = liters - (liters * 0.05);
                FuelTank += liters;
            }
        }
    }
}
