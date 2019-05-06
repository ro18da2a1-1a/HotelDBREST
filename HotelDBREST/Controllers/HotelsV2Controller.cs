using System.Collections.Generic;
using System.Web.Http;
using HotelDBREST.DBUtil.version2;
using ModelLib.model2;

namespace HotelDBREST.Controllers
{
    [RoutePrefix("api2/Hotels")]
    public class HotelsV2Controller : ApiController
    {
        private static ManageHotel2 mgr = new ManageHotel2();

        // GET: api2/Hotels
        [Route("")]
        public IEnumerable<Hotel> Get()
        {
            return mgr.Get();
        }

        [Route("Roskilde")]

        public IEnumerable<Hotel> GetFromRoskilde()
        {
            return mgr.GetFromRoskilde();
        }

        [Route("Filter")]
        public IEnumerable<Hotel> GetFilter([FromUri] HotelFilter filter)
        {
            return mgr.GetFilter(filter);
        }


        [Route("{id}")]
        // GET: api2/Hotels/5
        public Hotel Get(int id)
        {
            return mgr.Get(id);
        }

        

        // POST: api2/Hotels
        [Route("")]
        public bool Post([FromBody] Hotel h)
        {
            return mgr.Post(h);
        }


        [Route("{id}")]
        // PUT: api2/Hotels/5
        public bool Put(int id, [FromBody] Hotel h)
        {
            return mgr.Put(id, h);
        }

        [Route("{id}")]
        // DELETE: api2/Hotels/5
        public bool Delete(int id)
        {
            return mgr.Delete(id);
        }
    }
}
