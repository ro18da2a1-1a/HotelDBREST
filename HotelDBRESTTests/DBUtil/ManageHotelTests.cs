using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelDBREST.DBUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLib.model;

namespace HotelDBREST.DBUtil.Tests
{
    [TestClass()]
    public class ManageHotelTests
    {
       

        [TestMethod()]
        public void PutTest()
        {
            ManageHotel mgr = new ManageHotel();
            mgr.Post(new Hotel(10, "hotellet", "solvej45, 4000 Roskilde"));



            Hotel hotel = new Hotel(12, "Zealand Hostels", "mvej 34, 4000 Roskilde");


            bool res = mgr.Put(10, hotel);
            Assert.IsTrue(res);

            Hotel h = mgr.Get(12);

            Assert.AreEqual(12, h.Id);
            Assert.AreEqual("Zealand Hostels", h.Name);
            Assert.AreEqual("mvej 34, 4000 Roskilde", h.Address);

        }


    }
}