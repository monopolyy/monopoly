using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace server2.Builder
{
    public class HouseBuildDirector
    {
        private IHouseBuilder _builder;
      
        public void Construct()
        {
            _builder.NumberOfHouses = 1;
        }
    }
}
