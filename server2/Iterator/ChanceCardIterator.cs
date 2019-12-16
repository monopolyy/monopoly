using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Iterator
{
    public class ChanceCardIterator : IChanceCardIterator
    {
        private ChanceCardCollection chancecards;
        private int _current = 0;
        private int _step = 1;

        private ChanceCardIterator(ChanceCardCollection chance)
        {
            this.chancecards = chance;
        }
        public ChanceCards First()
        {
            _current = 0;
            return chancecards[_current] as ChanceCards;
        }
        public ChanceCards Next()
        {
            _current += _step;
            if (!isDone)
                return chancecards[_current] as ChanceCards;
            else
                return null;
        }
        public ChanceCards CurrentChance
        {
            get { return chancecards[_current] as ChanceCards; }

        }
        public bool isDone

        {
            get { return _current >= chancecards.Count; }
        }

    }
}
