using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    internal abstract class Room : IRoom
    {
        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
            PricePerNight = 0;
        }

        private double pricePerNight;

        public int BedCapacity { get; private set; }

        public double PricePerNight
        {
            get => pricePerNight;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
