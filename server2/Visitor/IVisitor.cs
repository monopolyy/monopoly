using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Visitor
{
    public interface IVisitor
    {
        void Visit(Element element);
    }
}
