using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Iterator
{
    public interface IChanceCardIterator
    {
        ChanceCards First();
        ChanceCards Next();
        bool isDone { get; }
        ChanceCards CurrentChance { get; }
    }
}
