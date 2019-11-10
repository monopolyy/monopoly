using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Decorator
{
    public abstract class Decorator : WholeStreet
    {
        private WholeStreet innerDecorator;

        public Decorator(WholeStreet component)
        {
            this.innerDecorator = component;
        }
        public override sealed int GetCost() {

            return GetPrice(this.innerDecorator.GetCost());
        }
        public abstract int GetPrice(int innerResult);
    }
}
