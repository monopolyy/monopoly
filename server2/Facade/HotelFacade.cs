using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Builder;
using server2.Models;

namespace server2.Facade
{
    public class HotelFacade
    {
        private readonly HotelName name;
        private readonly HotelPrice price;
        private readonly HotelBilling billing;

        public HotelFacade()
        {
            name = new HotelName();
            price = new HotelPrice();
            billing = new HotelBilling();
        }
        public void CreateCompleteCar(House house)
        {
            Console.WriteLine("******** Creating a Hotel **********");
            name.SetName(house,"Name");
            price.SetPrice(house,100000);
            billing.SetHotelBilling(house,25000);

            Console.WriteLine("******** Hotel creation is completed. **********");
        }
    }
}
