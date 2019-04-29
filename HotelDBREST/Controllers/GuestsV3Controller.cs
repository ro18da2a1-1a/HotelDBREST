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

    [System.Web.Http.RoutePrefix("api3/Guests")]
    public class GuestsV3Controller : ApiController
    {
        // GET: api/GuestsV3
        [Route("")]
        public IEnumerable<Guest> Get()
        {
            ManageGuestsController mgc = new ManageGuestsController();
            return ModelMapper.Ef2MGuestList(mgc.GetDemoGuests());
        }

        // GET: api/GuestsV3/5
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GuestsV3
        [Route("")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GuestsV3/5
        [Route("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GuestsV3/5
        [Route("{id}")]
        public void Delete(int id)
        {
        }
    }
}
