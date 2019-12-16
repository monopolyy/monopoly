using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Iterator
{
    public class ChanceCards
    {
        private int bonus;
        private string text;

        public ChanceCards(string text,int bonus)
        {
            this.text = text;
            this.bonus = bonus;
        }
        public int Bonus
        {
            get { return bonus; }

        }
        public string Text
        {
            get { return text; }

        }
    }
}
