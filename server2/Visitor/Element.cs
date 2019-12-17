using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;
namespace server2.Visitor
{
    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
}
