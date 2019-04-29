using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelDBREST.DBUtil.version3;
using ModelLib.model2;

namespace HotelDBREST.Controllers
{
    [RoutePrefix("api3/Hotels")]
    public class HotelsV3Controller : ApiController
    {
        // GET: api/HotelsV3
        [Route("")]
        public IEnumerable<Hotel> Get()
        {
            ManageHotelsController mhc = new ManageHotelsController();
            return ModelMapper.Ef2MHotelList(mhc.GetDemoHotels());

        }

        // GET: api/HotelsV3/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HotelsV3
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HotelsV3/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HotelsV3/5
        public void Delete(int id)
        {
        }
    }
}
