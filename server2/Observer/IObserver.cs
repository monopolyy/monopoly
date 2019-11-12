using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Observer
{
    public interface IObserver
    { 
        void Update(IStreet subject);
    }
}
