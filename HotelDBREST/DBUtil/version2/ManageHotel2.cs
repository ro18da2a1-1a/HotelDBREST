using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using ModelLib.model2;

namespace HotelDBREST.DBUtil.version2
{
    public class ManageHotel2: IManage<Hotel>
    {
        private const String GET_ALL = "select * from DemoHotel";
        private const String GET_ONE = "select * from DemoHotel WHERE Hotel_No = @ID";
        private const String DELETE = "delete from DemoHotel WHERE Hotel_No = @ID";
        private const String INSERT = "insert into DemoHotel values (@ID, @Name, @Address)";
        private const String UPDATE = "update DemoHotel " +
                                      "SET Hotel_no = @HotelId, Name = @Name, Address = @Address " +
                                      "WHERE Hotel_No = @ID";


        public IEnumerable<Hotel> Get()
        {
            List<Hotel> liste = new List<Hotel>();

            SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Hotel hotel = ReadHotel(reader);
                liste.Add(hotel);
            }
            reader.Close();

            foreach (Hotel h in liste)
            {
                h.AddRange(ReadHotelRooms(h.Id));
            }
            return liste;
        }

       public Hotel Get(int id)
        {
            Hotel hotel = null;

            SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                hotel = ReadHotel(reader);
                hotel.AddRange(ReadHotelRooms(hotel.Id));
            }
            reader.Close();

            return hotel;
        }

        

        

        public bool Post(Hotel hotel)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", hotel.Id);
            cmd.Parameters.AddWithValue("@Name", hotel.Name);
            cmd.Parameters.AddWithValue("@Address", hotel.Address);

            // TODO insert rooms

            int rowsAffected;
            try
            {
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }

            return rowsAffected == 1;
        }

        public bool Put(int id, Hotel hotel)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@HotelId", hotel.Id);
            cmd.Parameters.AddWithValue("@Name", hotel.Name);
            cmd.Parameters.AddWithValue("@Address", hotel.Address);

            // TODO update rooms

            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }



        private Hotel ReadHotel(SqlDataReader reader)
        {
            Hotel hotel = new Hotel();

            hotel.Id = reader.GetInt32(0);
            hotel.Name = reader.GetString(1);
            hotel.Address = reader.GetString(2);

            return hotel;
        }

        private IEnumerable<Room> ReadHotelRooms(int hid)
        {
            ManageRoom2 mgr = new ManageRoom2();
            return mgr.GetFromHotel(hid);
        }

        public IEnumerable<Hotel> GetFromRoskilde()
        {
            List<Hotel> liste = new List<Hotel>();

            String sql = "SELECT * FROM DemoHotel WHERE Address Like '%Roskilde%'";

            SqlCommand cmd = new SqlCommand(sql, SQLConnectionSingleton.Instance.DbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Hotel hotel = ReadHotel(reader);
                liste.Add(hotel);
            }
            reader.Close();

            foreach (Hotel h in liste)
            {
                h.AddRange(ReadHotelRooms(h.Id));
            }
            return liste;

        }
    }
}