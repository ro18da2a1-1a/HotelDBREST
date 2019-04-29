using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HotelDBREST.Models;

namespace HotelDBREST.DBUtil.version3
{
    public class ManageRoomsController : ApiController
    {
        private HotelDBModel db = new HotelDBModel();

        // GET: api/ManageRooms
        public IQueryable<DemoRoom> GetDemoRooms()
        {
            return db.DemoRooms;
        }

        // GET: api/ManageRooms/5
        [ResponseType(typeof(DemoRoom))]
        public IHttpActionResult GetDemoRoom(int id)
        {
            DemoRoom demoRoom = db.DemoRooms.Find(id);
            if (demoRoom == null)
            {
                return NotFound();
            }

            return Ok(demoRoom);
        }

        // PUT: api/ManageRooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDemoRoom(int id, DemoRoom demoRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != demoRoom.Room_No)
            {
                return BadRequest();
            }

            db.Entry(demoRoom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemoRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ManageRooms
        [ResponseType(typeof(DemoRoom))]
        public IHttpActionResult PostDemoRoom(DemoRoom demoRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DemoRooms.Add(demoRoom);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DemoRoomExists(demoRoom.Room_No))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = demoRoom.Room_No }, demoRoom);
        }

        // DELETE: api/ManageRooms/5
        [ResponseType(typeof(DemoRoom))]
        public IHttpActionResult DeleteDemoRoom(int id)
        {
            DemoRoom demoRoom = db.DemoRooms.Find(id);
            if (demoRoom == null)
            {
                return NotFound();
            }

            db.DemoRooms.Remove(demoRoom);
            db.SaveChanges();

            return Ok(demoRoom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DemoRoomExists(int id)
        {
            return db.DemoRooms.Count(e => e.Room_No == id) > 0;
        }
    }
}