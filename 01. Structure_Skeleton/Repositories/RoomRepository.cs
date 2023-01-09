using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    internal class RoomRepository : IRepository<IRoom>
    {
        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }

        private List<IRoom> rooms;
        public void AddNew(IRoom model)
        {
            rooms.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return rooms;
        }

        public IRoom Select(string criteria)
        {
            IRoom room = rooms.FirstOrDefault(r => r.GetType().Name == criteria);

            return room;
        }
    }
}
