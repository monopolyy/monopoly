using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Builder
{
    public abstract class HouseBuilder 
    {
        protected House house;
        public House House
        {
            get { return house; }
        }
        public abstract void BuildHouse();
        public abstract void BuildName();
        public abstract void BuildPrice();
        public abstract void BuildBilling();
    }
}
