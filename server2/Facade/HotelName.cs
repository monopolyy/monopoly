using server2.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Proxy;

namespace server2.Facade
{
    public class HotelName : IHotelName
    {
        public void SetName(House house)
        {
            house.Name = house.Name;
        }
    }
}
