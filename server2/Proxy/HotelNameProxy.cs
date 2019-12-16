using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Facade;
using server2.Builder;

namespace server2.Proxy
{
    public class HotelNameProxy : IHotelName
    {
        private HotelName _hotelName;

        public HotelNameProxy(HotelName realHotelName)
        {
            this._hotelName = realHotelName;
        }

        public void SetName(House house)
        {
            _hotelName.SetName(house);
        }
    }
}
