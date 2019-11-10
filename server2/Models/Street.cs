using System;
using System.Collections.Generic;
using server2.Observer;

namespace server2.Models
{
    public partial class Street : IStreet
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rent { get; set; }
        public int NeighbourHood { get; set; }
        public int Number { get; set; }
       // public int Type { get; set; }
        public int IdStreets { get; set; }
        public Nullable<int> FkPlayeridPlayer { get; set; }

        public Player FkPlayeridPlayerNavigation { get; set; }
        public NeighbourhoodType NeighbourHoodNavigation { get; set; }

        public void Attach(IObserver observer)
        {

        }
        public void Detach(IObserver observer)
        {

        }
        public void Notify()
        {

        }
    }
}
