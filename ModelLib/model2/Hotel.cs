using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model2
{
    public class Hotel
    {
        private int _id;
        private String _name;
        private String _address;
        private List<Room> _rooms;

        public Hotel():this(0,"dummy","dummy")
        {
        }

        public Hotel(int id, string name, string address)
        {
            _id = id;
            _name = name;
            _address = address;

            _rooms = new List<Room>();

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

        public List<Room> Rooms
        {
            get => _rooms;
            set => _rooms = value;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable) _rooms).GetEnumerator();
        }

        public void Add(Room item)
        {
            _rooms.Add(item);
        }

        public void AddRange(IEnumerable<Room> collection)
        {
            _rooms.AddRange(collection);
        }

        public Room this[int index]
        {
            get => _rooms[index];
            
        }

        public override string ToString()
        {
            string rooms = "[ (" + String.Join("),(", _rooms) + ") ]";
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}, {nameof(Rooms)}: {rooms}";
        }
    }
}
