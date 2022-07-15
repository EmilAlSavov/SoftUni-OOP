using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ');
            
            double tank = double.Parse(carInfo[1]);
            double consumption = double.Parse(carInfo[2]);
            double tankCapacity = double.Parse(carInfo[3]);

            Car car = new Car(tank, consumption, tankCapacity);

            string[] truckInfo = Console.ReadLine().Split(' ');

            double truckTank = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            Truck truck = new Truck(truckTank, truckConsumption, truckTankCapacity);

            string[] busInfo = Console.ReadLine().Split(' ');

            double busTank = double.Parse(busInfo[1]);
            double busConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Bus bus = new Bus(busTank, busConsumption, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ");

                string typeOfCommand = command[0];
                string truckOrCar = command[1];
                double quantity = double.Parse(command[2]);


                if (truckOrCar == "Car")
                {
                    if (typeOfCommand == "Drive")
                    {
                        car.Drive(quantity);
                    }
                    else if (typeOfCommand == "Refuel")
                    {
                        car.Refuel(quantity);
                    }
                }
                else if (truckOrCar == "Truck")
                {
                    if (typeOfCommand == "Drive")
                    {
                        truck.Drive(quantity);
                    }
                    else if (typeOfCommand == "Refuel")
                    {
                        truck.Refuel(quantity);
                    }
                }
                else if (truckOrCar == "Bus")
                {
                    if (typeOfCommand == "Drive")
                    {
                        bus.Drive(quantity);
                    }
                    else if (typeOfCommand == "Refuel")
                    {
                        bus.Refuel(quantity);
                    } else if (typeOfCommand == "DriveEmpty")
                    {
                        bus.DriveEmpty(quantity);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelTank:f2}");
            Console.WriteLine($"Truck: {truck.FuelTank:f2}");
            Console.WriteLine($"Bus: {bus.FuelTank:f2}");
        }
    }
}
