using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    internal class Booking : IBooking
    {
        public Booking(IRoom room, int redidenceDuration, int adultCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = redidenceDuration;
            this.AdultsCount = adultCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }

        private int residenceDuration;
        private int adultsCount;
        private int childernCount;

        public IRoom Room { get; set; }

        public int ResidenceDuration
        {
            get => residenceDuration;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }
                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => adultsCount;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }
                adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get => childernCount;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }
                childernCount = value;
            }
        }

        public int BookingNumber { get; private set; }

        public string BookingSummary()
        {
            return @$"Booking number: {BookingNumber}
Room type: { Room.GetType().Name}
Adults: { AdultsCount} Children: { ChildrenCount}
Total amount paid: { Math.Round(ResidenceDuration * Room.PricePerNight, 2):F2}$";

        }
    }
}
