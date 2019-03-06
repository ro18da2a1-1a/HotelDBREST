using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model
{
    public class Booking
    {
        private int _bookingId;
        private int _hotelNo;
        private int _roomNo;
        private int _guestNo;
        private DateTime _dateFrom;
        private DateTime _dateTo;

        public Booking()
        {
        }

        public Booking(int bookingId, int hotelNo, int roomNo, int guestNo, DateTime dateFrom, DateTime dateTo)
        {
            _bookingId = bookingId;
            _hotelNo = hotelNo;
            _roomNo = roomNo;
            _guestNo = guestNo;
            _dateFrom = dateFrom;
            _dateTo = dateTo;
        }

        public int BookingId
        {
            get => _bookingId;
            set => _bookingId = value;
        }

        public int HotelNo
        {
            get => _hotelNo;
            set => _hotelNo = value;
        }

        public int RoomNo
        {
            get => _roomNo;
            set => _roomNo = value;
        }

        public int GuestNo
        {
            get => _guestNo;
            set => _guestNo = value;
        }

        public DateTime DateFrom
        {
            get => _dateFrom;
            set => _dateFrom = value;
        }

        public DateTime DateTo
        {
            get => _dateTo;
            set => _dateTo = value;
        }

        public override string ToString()
        {
            return $"{nameof(BookingId)}: {BookingId}, {nameof(HotelNo)}: {HotelNo}, {nameof(RoomNo)}: {RoomNo}, {nameof(GuestNo)}: {GuestNo}, {nameof(DateFrom)}: {DateFrom}, {nameof(DateTo)}: {DateTo}";
        }
    }
}

