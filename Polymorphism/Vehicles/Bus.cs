using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    internal class Bus : Vehicle
    {
        public Bus(double fuelTank, double consumption, double tankCapacity) : base(fuelTank, consumption, tankCapacity)
        {
            Consumption += 1.4;
        }

        public void DriveEmpty(double distance)
        {
            Consumption -= 1.4;

            this.Drive(distance);

            Consumption += 1.4;
        }
    }
}
