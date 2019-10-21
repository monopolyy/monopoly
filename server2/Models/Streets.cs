using System;
using System.Collections.Generic;

namespace server2.Models
{
    public partial class Streets
    {
        public int Name { get; set; }
        public int Price { get; set; }
        public int Rent { get; set; }
        public int NeighbourHood { get; set; }

        public int Type { get; set; }
        public int IdStreets { get; set; }
        public int FkPlayeridPlayer { get; set; }

        public Player FkPlayeridPlayerNavigation { get; set; }
        public NeighbourhoodType NeighbourHoodNavigation { get; set; }
    }
}
