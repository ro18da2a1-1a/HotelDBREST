using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model
{
    public class Room
    {
        private int _roomNo;
        private int _hotelNo;
        private char _roomType;
        private double _price;

        public Room()
        {
        }

        public Room(int roomNo, int hotelNo, char roomType, double price)
        {
            _roomNo = roomNo;
            _hotelNo = hotelNo;
            _roomType = roomType;
            _price = price;
        }

        public int RoomNo
        {
            get => _roomNo;
            set => _roomNo = value;
        }

        public int HotelNo
        {
            get => _hotelNo;
            set => _hotelNo = value;
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

        public override string ToString()
        {
            return $"{nameof(RoomNo)}: {RoomNo}, {nameof(HotelNo)}: {HotelNo}, {nameof(RoomType)}: {RoomType}, {nameof(Price)}: {Price}";
        }
    }
}
