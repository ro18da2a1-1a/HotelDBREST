using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLib.model2;

namespace HotelDBREST.DBUtil.version2
{
    public class ManageRoom2 : IManage<Room>
    {
        private const String GET_ALL = "select * from DemoRoom";
        private const String GET_ONE = "select * from DemoRoom WHERE Hotel_No = @HID AND ROOM_No = @RID";
        private const String GET_ALL_FROM_HOTEL = "select * from DemoRoom WHERE Hotel_No = @HID";
        private const String DELETE = "delete from DemoRoom WHERE Hotel_No = @HID AND ROOM_No = @RID";
        private const String INSERT = "insert into DemoRoom values (@RID, @HID, @RType, @Price)";
        private const String UPDATE = "update DemoRoom " +
                                      "SET Hotel_no = @HotelId, Room_No = @RoomId, Types = @RType, Price = @Price " +
                                      "WHERE Hotel_No = @HID AND ROOM_No = @RID";


        protected Room ReadNextElement(SqlDataReader reader)
        {
            Room room = new Room();

            room.RoomNo = reader.GetInt32(0);
            //room.HotelNo = reader.GetInt32(1);
            room.RoomType = reader.GetString(2)[0];
            room.Price = reader.GetDouble(3);


            return room;
        }

        public IEnumerable<Room> Get()
        {
            List<Room> liste = new List<Room>();

            SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Room room = ReadNextElement(reader);
                liste.Add(room);
            }
            reader.Close();

            return liste;
        }

        public IEnumerable<Room> GetFromHotel(int hid)
        {
            List<Room> liste = new List<Room>();

            SqlCommand cmd = new SqlCommand(GET_ALL_FROM_HOTEL, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@HID", hid);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Room room = ReadNextElement(reader);
                liste.Add(room);
            }
            reader.Close();

            return liste;
        }

        public Room Get(int hid, int rid)
        {
            Room room = null;

            SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@HID", hid);
            cmd.Parameters.AddWithValue("@RID", rid);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                room = ReadNextElement(reader);
            }
            reader.Close();

            return room;
        }


        public bool Post(Room r, int hid)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@HID", hid);
            cmd.Parameters.AddWithValue("@RID", r.RoomNo);
            cmd.Parameters.AddWithValue("@RType", r.RoomType);
            cmd.Parameters.AddWithValue("@Price", r.Price);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Put(int hid, int rid, Room r)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@HotelId", hid);
            cmd.Parameters.AddWithValue("@RoomId", r.RoomNo);
            cmd.Parameters.AddWithValue("@RType", r.RoomType);
            cmd.Parameters.AddWithValue("@Price", r.Price);
            cmd.Parameters.AddWithValue("@HID", hid);
            cmd.Parameters.AddWithValue("@RID", rid);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;

        }

        public bool Delete(int hid, int rid)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@HID", hid);
            cmd.Parameters.AddWithValue("@RID", rid);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }


        /*
         * Not used methods from Generic interface - reason primary key has two columns
         */
        public bool Post(Room elem)
        {
            throw new NotImplementedException();
        }

        public bool Put(int id, Room elem)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Room Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}