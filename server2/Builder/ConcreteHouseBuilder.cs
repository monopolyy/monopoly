using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Builder
{
    public class ConcreteHouseBuilder : HouseBuilder
    {
        public ConcreteHouseBuilder()
        {
            house = new House("",0,0,0);
        }
        public override void BuildHouse()
        {
            House.NumberOfHouses = 1;
        }
        public override void BuildPrice()
        {
            House.Price = 20000;
        }
        public override void BuildBilling()
        {
            House.Billing = 5000;
        }
        public override void BuildName()
        {
            House.Name = "BMW";

        }
    }
}
