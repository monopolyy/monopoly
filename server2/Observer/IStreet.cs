using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Observer
{
    public interface IStreet
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}
