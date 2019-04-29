using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelDBREST.Models;
using ModelLib.model2;


namespace HotelDBREST.DBUtil.version3
{
    public class ModelMapper
    {
        public static Booking Ef2MBooking(DemoBooking efBooking)
        {
            Booking b = new Booking();
            b.Id = efBooking.Booking_id;
            b.From = efBooking.Date_From;
            b.To = efBooking.Date_To;

            return b;
        }

        public static IList<Booking> Ef2MBookingList(IEnumerable<DemoBooking> efBookings)
        {
            List<Booking> list = new List<Booking>();
            foreach (DemoBooking efBooking in efBookings)
            {
                list.Add(Ef2MBooking(efBooking));
            }
            return list;
        }

        public static Room Ef2MRoom(DemoRoom efRoom)
        {
            Room r = new Room();
            r.RoomNo = efRoom.Room_No;
            r.RoomType = efRoom.Types[0];
            r.Price = efRoom.Price==null? (double)efRoom.Price: 0;

            return r;
        }

        public static IList<Room> Ef2MRoomList(IEnumerable<DemoRoom> efRooms)
        {
            List<Room> list = new List<Room>();
            foreach (DemoRoom efRoom in efRooms)
            {
                
                    list.Add(Ef2MRoom(efRoom));
                
            }
            return list;
        }

        public static Hotel Ef2MHotel(DemoHotel efHotel)
        {
            Hotel h = new Hotel();
            h.Id = efHotel.Hotel_No;
            h.Address = efHotel.Address;
            h.Name = efHotel.Name;

            foreach (DemoRoom efRoom in efHotel.DemoRooms)
            {
                h.Rooms.Add(Ef2MRoom(efRoom));
            }
            

            return h;
        }

        public static IList<Hotel> Ef2MHotelList(IEnumerable<DemoHotel> efHotels)
        {
            List<Hotel> list = new List<Hotel>();
            foreach (DemoHotel efHotel in efHotels)
            {

                list.Add(Ef2MHotel(efHotel));

            }
            return list;
        }

        public static Guest Ef2MGuest(DemoGuest efGuest)
        {
            Guest g = new Guest();
            g.Id = efGuest.Guest_No;
            g.Address = efGuest.Address;
            g.Name = efGuest.Name;

            foreach (DemoBooking efBooking in efGuest.DemoBookings)
            {
                g.Bookings.Add(Ef2MBooking(efBooking));
            }


            return g;
        }

        public static IList<Guest> Ef2MGuestList(IEnumerable<DemoGuest> efGuests)
        {
            List<Guest> list = new List<Guest>();
            foreach (DemoGuest efGuest in efGuests)
            {

                list.Add(Ef2MGuest(efGuest));

            }
            return list;
        }

    }
}