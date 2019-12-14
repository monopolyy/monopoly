using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Proxy
{
    public interface ITax
    {
        int getTaxAmount();
        void setTaxAmount(int amount);
        int getNumber();
        void setNumber(int number);
        int getIdTax();
        void setIdTax(int id);
        
    }
}
