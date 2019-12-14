using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Proxy
{
    public class TaxProxy : ITax
    {
        private Tax _tax;

        public TaxProxy(Tax realTax)
        {
            this._tax = realTax;
        }

        public int getTaxAmount()
        {
            return _tax.getTaxAmount();
        }
        public void setTaxAmount(int amount)
        {
            _tax.setTaxAmount(amount);
        }
        public int getNumber()
        {
            return _tax.getNumber();
        }
        public void setNumber(int number)
        {
            _tax.setNumber(number);
        }
        public int getIdTax()
        {
            return _tax.getIdTax();
        }
        public void setIdTax(int id)
        {
            _tax.setIdTax(id);
        }
    }
}
