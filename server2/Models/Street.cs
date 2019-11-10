using System;
using System.Collections.Generic;
using server2.Observer;
using server2.Decorator;

namespace server2.Models
{
    public partial class Street : WholeStreet, IStreet
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rent { get; set; }
        public int NeighbourHood { get; set; }
        public int Number { get; set; }

        public int Level { get; set; }
        // public int Type { get; set; }
        public int IdStreets { get; set; }
        public Nullable<int> FkPlayeridPlayer { get; set; }

        public Player FkPlayeridPlayerNavigation { get; set; }
        public NeighbourhoodType NeighbourHoodNavigation { get; set; }

        public override int GetCost()
        {
            return this.Price;
        }

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
