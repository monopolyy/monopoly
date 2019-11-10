using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Builder;

namespace server2.Builder
{
    public class Example
    {
        public void build()
        {
            var builder = new HouseBuilder();
            var director = new HouseBuildDirector(builder);

            director.Construct();
            House myHouse = builder.GetResult();
        }
    }
}
