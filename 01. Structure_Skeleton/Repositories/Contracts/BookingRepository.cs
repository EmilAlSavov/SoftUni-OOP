using BookingApp.Models.Bookings.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories.Contracts
{
    internal class BookingRepository : IRepository<IBooking>
    {
        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }

        private List<IBooking> bookings;
        public void AddNew(IBooking model)
        {
            bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return bookings;
        }

        public IBooking Select(string criteria)
        {
            IBooking booking = bookings.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);

            return booking;
        }
    }
}
