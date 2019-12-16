using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Builder;
using server2.Models;
using server2.Proxy;

namespace server2.Facade
{
    public class HotelFacade
    {
        private readonly HotelName realName;
        private readonly HotelNameProxy name;

        private readonly HotelPrice realPrice;
        private readonly HotelPriceProxy price;

        private readonly HotelBilling realBilling;
        private readonly HotelBillingProxy billing;

        public HotelFacade()
        {
            realName = new HotelName();
            name = new HotelNameProxy(realName);

            realPrice = new HotelPrice();
            price = new HotelPriceProxy(realPrice);

            realBilling = new HotelBilling();
            billing = new HotelBillingProxy(realBilling);
        }
        public void CreateCompleteCar(House house)
        {
            Console.WriteLine("******** Creating a Hotel **********");
            name.SetName(house);
            price.SetPrice(house);
            billing.SetHotelBilling(house);

            Console.WriteLine("******** Hotel creation is completed. **********");
        }
    }
}
