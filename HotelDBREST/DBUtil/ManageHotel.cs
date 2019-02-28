using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using ModelLib.model;

namespace HotelDBREST.DBUtil
{
    public class ManageHotel
    {
        /*
         * Lokal database
         */
        private const String ConnString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PeleDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /*
         * Cloud Database
         */
        //private const String ConnString =
        //    @"Data Source=pele-easj-dbserver.database.windows.net;Initial Catalog=pele-easj-db;User ID=peleadm;Password=Secret1!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        private const String GET_ALL = "select * from DemoHotel";
        private const String GET_ONE = "select * from DemoHotel WHERE Hotel_No = @ID";
        private const String INSERT = "insert into DemoHotel values (@ID, @Name, @Address)";
        private const String DELETE  = "delete from DemoHotel WHERE Hotel_No = @ID";
        private const String UPDATE = "update DemoHotel " +
                                      "SET Hotel_no = @HotelId, Name = @Name, Address = @Address " +
                                      "WHERE Hotel_No = @ID";



        public IEnumerable<Hotel> Get()
        {
            List<Hotel> liste = new List<Hotel>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Hotel hotel = ReadHotel(reader);
                liste.Add(hotel);
            }

            conn.Close();

            return liste;
        }

        private Hotel ReadHotel(SqlDataReader reader)
        {
            Hotel hotel = new Hotel();

            hotel.Id = reader.GetInt32(0);
            hotel.Name = reader.GetString(1);
            hotel.Address = reader.GetString(2);

            return hotel;
        }

        // GET: api/Hotels/5
        public Hotel Get(int id)
        {
            Hotel hotel = null;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                hotel = ReadHotel(reader);
            }

            conn.Close();

            return hotel;
        }

        // POST: api/Hotels
        public bool Post(Hotel hotel)
        {
            bool retValue = false;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@ID", hotel.Id);
            cmd.Parameters.AddWithValue("@Name", hotel.Name);
            cmd.Parameters.AddWithValue("@Address", hotel.Address);

            int rowsAffected = cmd.ExecuteNonQuery();

            retValue = rowsAffected == 1 ? true : false;

            return retValue;
        }

        // PUT: api/Hotels/5
        public bool Put(int id, Hotel hotel)
        {
            bool retValue = false;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@HotelId", hotel.Id);
            cmd.Parameters.AddWithValue("@Name", hotel.Name);
            cmd.Parameters.AddWithValue("@Address", hotel.Address);

            int rowsAffected = cmd.ExecuteNonQuery();

            retValue = rowsAffected == 1 ? true : false;

            return retValue;
        }

     
        // DELETE: api/Hotels/5
        public bool Delete(int id)
        {
            bool retValue = false;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(DELETE, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            retValue = rowsAffected == 1 ? true : false;

            return retValue;

        }

    }
}