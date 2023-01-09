using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Models.Hotels
{
    internal class Hotel : IHotel
    {
        public Hotel(string name, int category)
        {
            this.FullName = name;
            this.Category = category;

            Rooms = new RoomRepository();
            Bookings = new BookingRepository();
        }

        private string name;
        private int category;

        public string FullName
        {
            get => name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }
                name = value;
            }
        }

        public int Category
        {
            get => category;

            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }
                category = value;
            }
        }

        public double Turnover => Math.Round(Bookings.All().Sum(x => x.ResidenceDuration * x.Room.PricePerNight), 2);

        public IRepository<IRoom> Rooms { get; set; }
        public IRepository<IBooking> Bookings { get; set; }
    }
}
