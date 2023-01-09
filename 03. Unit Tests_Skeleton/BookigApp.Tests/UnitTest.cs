using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateHotelIsNotNull()
        {
            Hotel hotel = new Hotel("HotelaNaEmo", 4);

            Assert.IsNotNull(hotel);
        }

        [Test]
        public void WhiteSpaceName_ThrowsArgumentNullExeption()
        {
            Hotel hotel = new Hotel("E", 3);

            Assert.That(() => hotel = new Hotel("  ", 3), Throws.ArgumentNullException);
        }

        [Test]
        public void CategoryUnder1_ThrowsArgumentExeption()
        {
            Hotel hotel = new Hotel("qkHotel", 3);

            Assert.That(() => hotel = new Hotel("qkHotel", 0), Throws.ArgumentException);
        }

        [Test]
        public void CategoryOver5_ThrowsArgumentExeption()
        {
            Hotel hotel = new Hotel("qkHotel", 3);

            Assert.That(() => hotel = new Hotel("qkHotel", 6), Throws.ArgumentException);
        }

        [Test]
        public void AddRoom()
        {
            Hotel hotel = new Hotel("qkHotel", 3);
            Room room = new Room(3, 40);

            hotel.AddRoom(room);

            Assert.That(hotel.Rooms.Count is 1);
        }

        [Test]
        public void AddBooking()
        {
            Hotel hotel = new Hotel("qkHotel", 3);
            Room room = new Room(3, 40);

            hotel.AddRoom(room);
            hotel.BookRoom(2, 1, 2, 80);

            Assert.That(hotel.Bookings.Count is 1);
        }

        [Test]
        public void BookRoomWithNoAdults_ThrowsArgumentException()
        {
            Hotel hotel = new Hotel("qkHotel", 3);
            Room room = new Room(3, 40);

            hotel.AddRoom(room);


            Assert.That(() => hotel.BookRoom(0, 1, 2, 80), Throws.ArgumentException);
        }

        [Test]
        public void BookRoomWithNegativeNumberOfKids_ThrowsArgumentException()
        {
            Hotel hotel = new Hotel("qkHotel", 3);
            Room room = new Room(3, 40);

            hotel.AddRoom(room);


            Assert.That(() => hotel.BookRoom(1, -1, 2, 80), Throws.ArgumentException);
        }

        [Test]
        public void BookRoomWithNoDuration_ThrowsArgumentException()
        {
            Hotel hotel = new Hotel("qkHotel", 3);
            Room room = new Room(3, 40);

            hotel.AddRoom(room);


            Assert.That(() => hotel.BookRoom(2, 1, 0, 80), Throws.ArgumentException);
        }

        [Test]
        public void BookWithTheSmallestRooms()
        {
            Hotel hotel = new Hotel("qkHotel", 3);
            Room room = new Room(3, 40);
            Room room2 = new Room(2, 40);
            Room room3 = new Room(8, 40);
            Room room4 = new Room(10, 40);

            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);
            hotel.AddRoom(room4);

            hotel.BookRoom(2, 0, 2, 80);

            Assert.That(hotel.Bookings.First().Room == room2);
        }

        [Test]
        public void NoMoney_NoBooking()
        {
            Hotel hotel = new Hotel("qkHotel", 3);
            Room room = new Room(3, 40);
            Room room2 = new Room(2, 40);
            Room room3 = new Room(8, 40);
            Room room4 = new Room(10, 40);

            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);
            hotel.AddRoom(room4);

            hotel.BookRoom(2, 0, 2, 20);

            Assert.That(hotel.Bookings.Count is 0);
        }

    }
}