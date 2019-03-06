using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDBREST.DBUtil;
using ModelLib.model;

namespace TjekREST
{
    class Program
    {
        static void Main(string[] args)
        {
            ///*
            // * Hotel
            // */
            // ManageHotel hmgr = new ManageHotel();

            //Console.WriteLine("Alle hoteller");
            //foreach (Hotel h in hmgr.Get())
            //{
            //    Console.WriteLine(h);
            //}

            //Console.WriteLine("Et hotel no3");
            //Console.WriteLine(hmgr.Get(3));

            //Console.WriteLine("opret hotel");
            //Console.WriteLine(hmgr.Post(new Hotel(100, "peters", "vejen 3")));
            //Console.WriteLine(hmgr.Get(100));

            //Console.WriteLine("ændre hotel");
            //Console.WriteLine(hmgr.Put(100, new Hotel(100, "pouls", "gaden 3")));
            //Console.WriteLine(hmgr.Get(100));

            //Console.WriteLine("Slet hotel 100");
            //Console.WriteLine(hmgr.Delete(100));
            //Console.WriteLine(hmgr.Get(100));

            ///*
            // * Guest
            // */
            //ManageGuest gmgr = new ManageGuest();

            //Console.WriteLine("Alle gæster");
            //foreach (Guest g in gmgr.Get())
            //{
            //    Console.WriteLine(g);
            //}

            //Console.WriteLine("En Gæst no4");
            //Console.WriteLine(gmgr.Get(4));

            //Console.WriteLine("opret gæst");
            //Console.WriteLine(gmgr.Post(new Guest(100, "peter", "vejen 3")));
            //Console.WriteLine(gmgr.Get(100));

            //Console.WriteLine("ændre gæst");
            //Console.WriteLine(gmgr.Put(100, new Guest(100, "poul", "gaden 3")));
            //Console.WriteLine(gmgr.Get(100));

            //Console.WriteLine("Slet gæst 100");
            //Console.WriteLine(gmgr.Delete(100));
            //Console.WriteLine(gmgr.Get(100));


            ///*
            // * Room
            // */
            //ManageRoom rmgr = new ManageRoom();

            //Console.WriteLine("Alle værelser");
            //foreach (Room r in rmgr.Get())
            //{
            //    Console.WriteLine(r);
            //}

            //Console.WriteLine("En værelse no4");
            //Console.WriteLine(rmgr.Get(4,1));

            //Console.WriteLine("opret værelse");
            //Console.WriteLine(rmgr.Post(new Room(400, 4, 'S', 234.4)));
            //Console.WriteLine(rmgr.Get(4,400));

            //Console.WriteLine("ændre værelse");
            //Console.WriteLine(rmgr.Put(100, 4, new Room(400, 4, 'F', 287.5)));
            //Console.WriteLine(rmgr.Get(4,400));

            //Console.WriteLine("Slet værelse 100");
            //Console.WriteLine(rmgr.Delete(4, 400));
            //Console.WriteLine(rmgr.Get(4, 400));

            /*
             * Guest
             */
            ManageBooking bmgr = new ManageBooking();

            Console.WriteLine("Alle bookninger");
            foreach (Booking b in bmgr.Get())
            {
                Console.WriteLine(b);
            }

            Console.WriteLine("En bookning no4");
            Console.WriteLine(bmgr.Get(4));

            Console.WriteLine("opret bookning");
            Console.WriteLine(bmgr.Post(new Booking(100, 4,1,5,DateTime.Parse("2019-03-07"), DateTime.Parse("2019-03-09"))));
            /*
             * display all incl the new
             */
            Console.WriteLine("Alle bookninger");
            foreach (Booking b in bmgr.Get())
            {
                Console.WriteLine(b);
            }

            Console.Write("Give latest / highest b-no : ");
            int bno = Int32.Parse(Console.ReadLine());
            Console.WriteLine(bmgr.Get(bno));

            Console.WriteLine("ændre bookning " + bno);
            Console.WriteLine(bmgr.Put(bno, new Booking(100, 5, 2, 2, DateTime.Parse("2019-03-17"), DateTime.Parse("2019-03-19"))));
            Console.WriteLine(bmgr.Get(bno));

            Console.WriteLine("Slet bookning " + bno);
            Console.WriteLine(bmgr.Delete(bno));
            Console.WriteLine(bmgr.Get(bno));


            Console.ReadLine();
        }
    }
}
