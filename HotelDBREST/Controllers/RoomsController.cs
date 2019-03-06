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
    public class RoomsController : ApiController
    {
        private static ManageRoom manager = new ManageRoom();
        // GET: api/Rooms
        public IEnumerable<Room> Get()
        {
            return manager.Get();
        }

        // GET: api/Rooms/5
        [Route ("api/Rooms/{rid}/hotelId/{hid}")]
        public Room Get(int rid, int hid)
        {
            return manager.Get(hid,rid);
        }

        // POST: api/Rooms
        public bool Post([FromBody]Room room)
        {
            return manager.Post(room);
        }

        // PUT: api/Rooms/5
        [Route("api/Rooms/{rid}/hotelId/{hid}")]
        public bool Put(int rid, int hid, [FromBody]Room room)
        {
            return manager.Put(hid, rid, room);
        }

        // DELETE: api/Rooms/5
        [Route("api/Rooms/{rid}/hotelId/{hid}")]
        public bool Delete(int rid, int hid)
        {
            return manager.Delete(hid, rid);
        }
    }
}
