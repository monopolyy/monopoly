using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Facade;
using server2.Builder;

namespace server2.Proxy
{
    public class HotelBillingProxy : IHotelBilling
    {
        private HotelBilling _hotelBilling;

        public HotelBillingProxy(HotelBilling realHotelBilling)
        {
            this._hotelBilling = realHotelBilling;
        }

        public void SetHotelBilling(House house)
        {
            _hotelBilling.SetHotelBilling(house);
        }
    }
}
