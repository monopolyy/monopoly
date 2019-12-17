using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Decorator;

namespace server2.Interpreter
{
    public class Star2Expression : Expression
    {
        WholeStreet component;
        public Star2Expression(WholeStreet comp)
        {
            component = comp;
        }
        public WholeStreet star (WholeStreet comp)
        {
            component = new Star2nd(comp);
            return component;
        }
    }
}
