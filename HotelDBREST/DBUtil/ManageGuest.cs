using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLib.model;

namespace HotelDBREST.DBUtil
{
    public class ManageGuest : IManage<Guest>
    {
        private const String GET_ALL = "select * from DemoGuest";
        private const String GET_ONE = "select * from DemoGuest WHERE Guest_No = @ID";
        private const String DELETE = "delete from DemoGuest WHERE Guest_No = @ID";
        private const String INSERT = "insert into DemoGuest values (@ID, @Name, @Address)";
        private const String UPDATE = "update DemoGuest " +
                                      "SET Guest_No = @GuestId, Name = @Name, Address = @Address " +
                                      "WHERE Guest_No = @ID";



        protected Guest ReadNextElement(SqlDataReader reader)
        {
            Guest guest = new Guest();

            guest.Id = reader.GetInt32(0);
            guest.Name = reader.GetString(1);
            guest.Address = reader.GetString(2);

            return guest;
        }


        public IEnumerable<Guest> Get()
        {
            List<Guest> liste = new List<Guest>();

            SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Guest guest = ReadNextElement(reader);
                liste.Add(guest);
            }
            reader.Close();

            return liste;
        }

        public Guest Get(int id)
        {
            Guest guest = null;

            SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                guest = ReadNextElement(reader);
            }
            reader.Close();

            return guest;
        }

        public bool Post(Guest g)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", g.Id);
            cmd.Parameters.AddWithValue("@Name", g.Name);
            cmd.Parameters.AddWithValue("@Address", g.Address);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Put(int id, Guest g)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@GuestId", g.Id);
            cmd.Parameters.AddWithValue("@Name", g.Name);
            cmd.Parameters.AddWithValue("@Address", g.Address);
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