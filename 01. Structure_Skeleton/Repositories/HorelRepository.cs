using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    internal class HorelRepository : IRepository<IHotel>
    {
        public HorelRepository()
        {
            hotels = new List<IHotel>();
        }

        private List<IHotel> hotels;
        public void AddNew(IHotel model)
        {
            hotels.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return hotels;
        }

        public IHotel Select(string criteria)
        {
            IHotel hotel = hotels.FirstOrDefault(x => x.FullName == criteria);

            return hotel;
        }
    }
}
