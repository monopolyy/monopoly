using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Decorator;

namespace server2.Interpreter
{
    public interface Expression
    {
        WholeStreet star(WholeStreet component);
    }
}
