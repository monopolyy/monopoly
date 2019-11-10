using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Builder
{
    public class HouseBuilder : IHouseBuilder
    {
        public int NumberOfHouses { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Billing { get; set; }
        public House GetResult()
        {
            return NumberOfHouses == 1 ? new House(Name, Price, Billing, NumberOfHouses) : null;

        }
    }
}
