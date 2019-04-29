using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model2
{
    public class Guest
    {
        private int _id;
        private String _name;
        private String _address;
        private List<Booking> _bookings;

        // HUSK ALTID EN DEFAULT konstruktør til JSON
        public Guest()
        {
            _bookings = new List<Booking>();
        }

        public Guest(int id, string name, string address)
        {
            _id = id;
            _name = name;
            _address = address;
            _bookings = new List<Booking>();
        }

        public List<Booking> Bookings
        {
            get => _bookings;
            set => _bookings = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public override string ToString()
        {
            string bookingstr = string.Join(",", _bookings);
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}, Bookings: [{bookingstr}]";
        }
    }
}
