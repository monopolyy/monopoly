using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Builder
{
    public class ConcreteHouseBuilder : HouseBuilder
    {
        public ConcreteHouseBuilder(House housee)
        {
            house = new House(house.Name,house.Price,house.Billing,0);
        }
        public override void BuildHouse()
        {
            House.NumberOfHouses = 1;
        }
        public override void BuildPrice()
        {
            House.Price = house.Price;
        }
        public override void BuildBilling()
        {
            House.Billing = house.Billing + 150;
        }
        public override void BuildName()
        {
            House.Name = house.Name;

        }
    }
}
