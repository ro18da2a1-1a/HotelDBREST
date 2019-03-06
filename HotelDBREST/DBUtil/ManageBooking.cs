using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLib.model;

namespace HotelDBREST.DBUtil
{
    public class ManageBooking: IManage<Booking>
    {
        private const String GET_ALL = "select * from DemoBooking";
        private const String GET_ONE = "select * from DemoBooking WHERE Booking_id = @ID";
        private const String DELETE = "delete from DemoBooking WHERE Booking_id = @ID";
        private const String INSERT = "insert into DemoBooking values (@HID, @GID, @DFROM, @DTO, @RID)";
        private const String UPDATE = "update DemoBooking " +
                                      "SET Hotel_No = @HID, Guest_No = @GID, Date_From = @DFROM, Date_To = @DTO, Room_No = @RID " +
                                      "WHERE Booking_id = @ID";

       protected Booking ReadNextElement(SqlDataReader reader)
        {
            Booking booking = new Booking();

            booking.BookingId = reader.GetInt32(0);
            booking.HotelNo = reader.GetInt32(1);
            booking.GuestNo = reader.GetInt32(2);
            booking.DateFrom = reader.GetDateTime(3);
            booking.DateTo = reader.GetDateTime(4);
            booking.RoomNo = reader.GetInt32(5);

            return booking;
        }


        public IEnumerable<Booking> Get()
        {
            List<Booking> liste = new List<Booking>();

            SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Booking booking = ReadNextElement(reader);
                liste.Add(booking);
            }
            reader.Close();

            return liste;
        }

        public Booking Get(int id)
        {
            Booking booking = null;

            SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);
            
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                booking = ReadNextElement(reader);
            }
            reader.Close();

            return booking;
        }

        public bool Post(Booking b)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@HID", b.HotelNo);
            cmd.Parameters.AddWithValue("@RID", b.RoomNo);
            cmd.Parameters.AddWithValue("@DFROM", b.DateFrom);
            cmd.Parameters.AddWithValue("@DTO", b.DateTo);
            cmd.Parameters.AddWithValue("@GID", b.GuestNo);


            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Put(int id, Booking b)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@HID", b.HotelNo);
            cmd.Parameters.AddWithValue("@RID", b.RoomNo);
            cmd.Parameters.AddWithValue("@DFROM", b.DateFrom);
            cmd.Parameters.AddWithValue("@DTO", b.DateTo);
            cmd.Parameters.AddWithValue("@GID", b.GuestNo);
            cmd.Parameters.AddWithValue("@ID", id);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }
    }
}