using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Visitor
{
    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
}
