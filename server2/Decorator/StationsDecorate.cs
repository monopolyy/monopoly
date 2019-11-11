using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Decorator;

namespace server2.Decorator
{
    public class StationsDecorate :Decorator
    {
        public StationsDecorate(WholeStreet decorator) : base(decorator)
        {

        }

        public override int GetPrice(int innerResult)
        {
            return innerResult * 2;
        }
    }
}
