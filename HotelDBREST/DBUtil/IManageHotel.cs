using System.Collections.Generic;
using ModelLib.model;

namespace HotelDBREST.DBUtil
{
    public interface IManageHotel
    {
        IEnumerable<Hotel> Get();
        Hotel Get(int id);
        bool Post(Hotel hotel);
        bool Put(int id, Hotel hotel);
        bool Delete(int id);
    }
}