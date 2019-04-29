using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model2
{
    public class Booking
    {
        private Guest _guest;
        private Room _room;
        private Hotel _hotel;
        private DateTime _from;
        private DateTime _to;
        private int _id;


        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public Guest Guest
        {
            get => _guest;
            set => _guest = value;
        }

        public Room Room
        {
            get => _room;
            set => _room = value;
        }

        public Hotel Hotel
        {
            get => _hotel;
            set => _hotel = value;
        }

        public DateTime From
        {
            get => _from;
            set => _from = value;
        }

        public DateTime To
        {
            get => _to;
            set => _to = value;
        }

        public Booking()
        {
        }

        public Booking(int id, Guest guest, Room room, Hotel hotel, DateTime @from, DateTime to)
        {
            _id = id;
            _guest = guest;
            _room = room;
            _hotel = hotel;
            _from = @from;
            _to = to;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Guest)}: {Guest}, {nameof(Room)}: {Room}, {nameof(Hotel)}: {Hotel}, {nameof(From)}: {From}, {nameof(To)}: {To}";
        }
    }
}
