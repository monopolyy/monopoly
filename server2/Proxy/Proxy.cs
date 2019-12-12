using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Proxy
{
    public class Proxy : ITax
    {
        private Tax _tax = new Tax();

        public int getTaxAm()
        {
            return _tax.getTaxAmount();
        }
        public int getNum()
        {
            return _tax.getNumber();
        }
        public int getId()
        {
            return _tax.getIdTax();
        }
    }
}
