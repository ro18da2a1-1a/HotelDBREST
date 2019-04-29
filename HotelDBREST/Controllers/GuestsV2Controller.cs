using System.Collections.Generic;
using System.Web.Http;
using HotelDBREST.DBUtil.version2;
using ModelLib.model2;

namespace HotelDBREST.Controllers
{
    [RoutePrefix("api2/Guests")]
    public class GuestsV2Controller : ApiController
    {
        private static ManageGuest2 mgr = new ManageGuest2();

        [Route("")]
        // GET: api/Guests
        public IEnumerable<Guest> Get()
        {
            return mgr.Get();
        }

        [Route("{id}")]
        // GET: api/Guests/5
        public Guest Get(int id)
        {
            return mgr.Get(id);
        }

        // POST: api/Guests
        public bool Post([FromBody]Guest g)
        {
            return mgr.Post(g);
        }

        [Route("{id}")]
        // PUT: api/Guests/5
        public bool Put(int id, [FromBody]Guest g)
        {
            return mgr.Put(id, g);
        }

        [Route("{id}")]
        // DELETE: api/Guests/5
        public bool Delete(int id)
        {
            return mgr.Delete(id);
        }
    }
}
