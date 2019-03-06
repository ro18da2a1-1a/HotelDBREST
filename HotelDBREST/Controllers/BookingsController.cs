using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelDBREST.DBUtil;
using ModelLib.model;

namespace HotelDBREST.Controllers
{
    

    public class BookingsController : ApiController
    {
        private static IManage<Booking> manager = new ManageBooking();

        // GET: api/Bookings
        public IEnumerable<Booking> Get()
        {
            return manager.Get();
        }

        // GET: api/Bookings/5
        public Booking Get(int id)
        {
            return manager.Get(id);
        }

        // POST: api/Bookings
        public bool Post([FromBody]Booking booking)
        {
            return manager.Post(booking);
        }

        // PUT: api/Bookings/5
        public bool Put(int id, [FromBody]Booking booking)
        {
            return manager.Put(id, booking);
        }

        // DELETE: api/Bookings/5
        public bool Delete(int id)
        {
            return manager.Delete(id);
        }
    }
}
