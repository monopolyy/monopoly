using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Builder;

namespace server2.Proxy
{
    public interface IHotelBilling
    {
        void SetHotelBilling(House house);
    }
}
