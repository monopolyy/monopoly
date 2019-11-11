using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Decorator
{
    public class Star3rd:Decorator
    { 
        public Star3rd(WholeStreet decorator) : base(decorator)
        {

        }

        public override int GetPrice(int innerResult)
        {
            return innerResult * 2;
        }
    }
}
