using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Decorator;

namespace server2.Interpreter
{
    public class TerminalExpression : Expression
    {
        WholeStreet data;

        public TerminalExpression(WholeStreet data)
        {
            this.data = data;
        }

        public WholeStreet star(WholeStreet component)
        {
            if (data == component)
            {
                return component;
            }
            else
            {
                return data;
            }
        }
        /*public bool interpreter(WholeStreet component)
        {
            if (data == component)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
    }
}
