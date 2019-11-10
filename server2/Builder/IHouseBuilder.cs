using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace server2.Builder
{
    interface IHouseBuilder
    {
        int NumberOfHouses { get; set; }
        House GetResult();
    }
}
