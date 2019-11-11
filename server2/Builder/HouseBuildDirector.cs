using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Builder
{
    public class HouseBuildDirector
    {
        public void Construct(HouseBuilder housebuilder)
        {
            housebuilder.BuildBilling();
            housebuilder.BuildHouse();
            housebuilder.BuildName();
            housebuilder.BuildPrice();
        }
    }
}
