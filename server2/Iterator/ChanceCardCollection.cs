using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace server2.Iterator
{
    public class ChanceCardCollection : ICardCollection
    {
        private ArrayList cards = new ArrayList();

        //public ChanceCardIterator CreateIterator()
        //{
            //return new ChanceCardIterator(this);
        //}

        IChanceCardIterator ICardCollection.CreateIterator()
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return cards.Count; }
        }
        public object this[int index]
        {
            get { return cards[index]; }
            //get { cards.Add(value); }
        }
    }
}
