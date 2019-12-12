using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Proxy
{
    public interface ITax
    {
        int getTaxAmount();
        int getNumber();
        int getIdTax();
    }
}
