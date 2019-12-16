using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Facade;
using server2.Builder;

namespace server2.Proxy
{
    public class HotelPriceProxy : IHotelPrice
    {
        private HotelPrice _hotelPrice;

        public HotelPriceProxy(HotelPrice realHotelPrice)
        {
            this._hotelPrice = realHotelPrice;
        }

        public void SetPrice(House house)
        {
            _hotelPrice.SetPrice(house);
        }
    }
}
