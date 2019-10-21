using System;
using System.Collections.Generic;

namespace server2.Models
{
    public partial class Player
    {
        public Player()
        {
            Streets = new HashSet<Streets>();
        }

        public string Name { get; set; }
        public int CurrentPosition { get; set; }
        public int IndexP { get; set; }
        public bool IsInJail { get; set; }
        public int MoneyP { get; set; }
        public int IdPlayer { get; set; }

        public ICollection<Streets> Streets { get; set; }
    }
}
