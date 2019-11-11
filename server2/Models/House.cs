using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Builder // and Prototype too
{
    public class House
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Billing { get; set; }
        public int NumberOfHouses { get; set; }
        public House()
        {
            Name = "";
            Price = 0;
            Billing = 0;
            NumberOfHouses = 0;
        }
        public House(string name, int price, int billing, int numberofhouses)
        {
            Name = name;
            Price = price;
            Billing = billing;
            NumberOfHouses = numberofhouses;
        }
        // Keisis jeigu pasikeis šablonas
        public House ShallowCopy()
        {
            return (House)this.MemberwiseClone();
        }
        // Keičia tik tas reikšmes, kurios yra užpildytos per parametrus
        // -1 arba "" reiškia, kad reikšmės keisti nereikia
        public House DeepCopy(string changeName, int changePrice, int changeBilling,
            int changeNumberofhouses)
        {
            House clone = (House)this.MemberwiseClone();
            if (changeName != "")
            {
                clone.Name = changeName;
            }
            if (changePrice > -1)
            {
                clone.Price = changePrice;
            }
            if (changeBilling > -1)
            {
                clone.Billing = changeBilling;
            }
            if (changeNumberofhouses > -1)
            {
                clone.NumberOfHouses = changeNumberofhouses;
            }
            return clone;
        }
    }
}
