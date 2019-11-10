using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Builder
{
    public class House
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Billing { get; set; }
        public int NumberOfHouses { get; set; }
        public House(string name, int price, int billing, int numberofhouses)
        {
            Name = name;
            Price = price;
            Billing = billing;
            NumberOfHouses = numberofhouses;
        }
    }
}
