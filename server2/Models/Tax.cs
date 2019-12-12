using System;
using System.Collections.Generic;
using server2.Proxy;

namespace server2.Models
{
    public partial class Tax : ITax
    {
        public int TaxAmount { get; set; }

        public int Number { get; set; }
        public int IdTax { get; set; }

        public int getTaxAmount()
        {
            Console.WriteLine("Tax: Handling getTaxAmount request.");
            return TaxAmount;
        }
        public int getNumber()
        {
            Console.WriteLine("Tax: Handling getNumber request.");
            return Number;
        }
        public int getIdTax()
        {
            Console.WriteLine("Tax: Handling getIdTax request.");
            return IdTax;
        }
    }
}
