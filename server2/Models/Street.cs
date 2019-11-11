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
            return this.Rent;
        }

        private List<IObserver> _observers = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            Console.WriteLine("Street: Attached an observer.");
            this._observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Street: Detached an observer.");
        }
        public void Notify()
        {
            Console.WriteLine("Street: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
        public void SomeActions()
        {
            Console.WriteLine("\nStreet: Changing the owner of {0} street!", this.Name);
            this.Notify();
        }
    }
}
