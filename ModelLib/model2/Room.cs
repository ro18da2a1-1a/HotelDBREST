using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model2
{
    public class Room
    {
        private int _roomNo;
        private char _roomType;
        private double _price;
        private List<Booking> _bookingList;


        public int RoomNo
        {
            get => _roomNo;
            set => _roomNo = value;
        }

        public char RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }

        public List<Booking> BookingList
        {
            get => _bookingList;
            set => _bookingList = value;
        }

        public Room()
        {
            _bookingList = new List<Booking>();
        }

        public Room(int roomNo, char roomType, double price)
        {
            _roomNo = roomNo;
            _roomType = roomType;
            _price = price;
            _bookingList = new List<Booking>();
        }

        public override string ToString()
        {
            String bookningstr = String.Join(",", _bookingList);
            return $"{nameof(RoomNo)}: {RoomNo}, {nameof(RoomType)}: {RoomType}, {nameof(Price)}: {Price}, Bookings: [{bookningstr}] ";
        }
    }
}
