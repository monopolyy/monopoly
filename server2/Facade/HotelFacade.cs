using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Facade
{
    public class HotelFacade
    {
        private readonly HotelStreetName streetname;
        private readonly HotelName name;
        private readonly HotelPrice price;

        public HotelFacade()
        {
            streetname = new HotelStreetName();
            name = new HotelName();
            price = new HotelPrice();
        }
        public void CreateCompleteCar()
        {
            Console.WriteLine("******** Creating a Hotel **********");
            streetname.SetStreetName();
            name.SetName();
            price.SetPrice();

            Console.WriteLine("******** Hotel creation is completed. **********");
        }
    }
}
