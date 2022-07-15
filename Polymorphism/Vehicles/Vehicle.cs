using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    internal class Vehicle
    {
        public Vehicle(double fuelTank, double consumption, double tankCapacity)
        {
            this.Consumption = consumption;
            this.TankCapacity = tankCapacity;

            if (TankCapacity>= fuelTank)
            {
                this.FuelTank = fuelTank;
            }
            else
            {
                this.FuelTank = 0;
            }
        }

        public double FuelTank { get; set; }

        public double Consumption { get; set; }

        public double TankCapacity { get; set; }

        public virtual void Drive(double distance)
        {
            if (FuelTank >= Consumption * distance)
            {
                FuelTank -= Consumption * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                return;
            }
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }

        public virtual void Refuel(double liters)
        {
            if (FuelTank + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            } else
            {
                FuelTank += liters;
            }
        }
    }
}
