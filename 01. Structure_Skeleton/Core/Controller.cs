using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    internal class Controller : IController
    {
        public Controller()
        {
            hotels = new HorelRepository();
        }
        private HorelRepository hotels;
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = hotels.All().FirstOrDefault(h => h.FullName == hotelName);

            if (hotel == null)
            {
                hotel = new Hotel(hotelName, category);
                hotels.AddNew(hotel);
                return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
            }

            return $"Hotel {hotelName} is already registered in our platform.";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> availableHotels = hotels.All().Where(h => h.Category == category).OrderBy(h => h.FullName).ToList();

            int people = adults + children;

            if (availableHotels.Count > 0)
            {
                foreach (var hotel in availableHotels)
                {
                    IRoom room = hotel.Rooms.All().Where(r => r.PricePerNight > 0).OrderBy(r => r.BedCapacity).FirstOrDefault(r => r.BedCapacity >= people);

                    if (room != null)
                    {
                        hotel.Bookings.AddNew(new Booking(room, duration, adults, children, hotel.Bookings.All().Count + 1));
                        return $"Booking number {hotel.Bookings.All().Count} for {hotel.FullName} hotel is successful!";
                    }
                }
                return "We cannot offer appropriate room for your request.";
            }
            return $"{category} star hotel is not available in our platform.";
        }

        public string HotelReport(string hotelName)
        {
            StringBuilder result = new StringBuilder();
            IHotel hotel = hotels.Select(hotelName);

            if (hotel != null)
            {
                result.AppendLine(@$"Hotel name: {hotelName}
--{hotel.Category} star hotel
--Turnover: {hotel.Turnover:F2} $
--Bookings:
");
                if (hotel.Bookings.All().Count > 0)
                {
                    foreach (var booking in hotel.Bookings.All())
                    {
                        result.AppendLine(booking.BookingSummary());
                        result.AppendLine();
                    }
                }
                else
                {
                    result.AppendLine("none");
                }
                return result.ToString().Trim();
            }
            return $"Profile {hotelName} doesn’t exist!";
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel != null)
            {
                if (roomTypeName == "DoubleBed" || roomTypeName == "Apartment" || roomTypeName == "Studio")
                {
                    IRoom room = hotel.Rooms.Select(roomTypeName);
                    if (room != null)
                    {
                        if (room.PricePerNight == 0)
                        {
                            room.SetPrice(price);

                            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
                        }
                        return "Price is already set!";
                    }
                    return "Room type is not created yet!";
                }
                else
                {
                    throw new ArgumentException("Incorrect room type!");
                }
            }
            return $"Profile {hotelName} doesn’t exist!";
        }
    
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel != null)
            {
                if (!hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
                {
                    if (roomTypeName == "DoubleBed")
                    {
                        hotel.Rooms.AddNew(new DoubleBed());
                    }
                    else if (roomTypeName == "Apartment")
                    {
                        hotel.Rooms.AddNew(new Apartment());
                    }
                    else if (roomTypeName == "Studio")
                    {
                        hotel.Rooms.AddNew(new Studio());
                    }
                    else
                    {
                        throw new ArgumentException("Incorrect room type!");
                    }
                    return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
                }
                return "Room type is already created!";
            }
            return $"Profile {hotelName} doesn’t exist!";
        }
    }
}
