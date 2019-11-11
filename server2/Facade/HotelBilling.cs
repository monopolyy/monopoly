using server2.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Facade
{
    public class HotelBilling
    {
        public void SetHotelBilling(House house)
        {
            house.Billing = house.Billing*2;
            
        }
    }
}
