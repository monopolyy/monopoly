using System;
using System.Collections.Generic;

namespace server2.Models
{
    public partial class Player
    {
        public Player()
        {
            Streets = new HashSet<Street>();
        }

        public string Name { get; set; }
        public int CurrentPosition { get; set; }
        public int IndexP { get; set; }
        public bool IsInJail { get; set; }
        public int Turn { get; set; }
        public int MoneyP { get; set; }
        public int IdPlayer { get; set; }

        public ICollection<Street> Streets { get; set; }
    }
}
