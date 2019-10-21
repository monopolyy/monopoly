using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model.Enums;
using Monopoly2019.Model.Interfaces;


namespace Monopoly2019.Model.Tiles
{
    public class Street : Tile, ITile
    {
        public NeighbourhoodType NeighbourHood { get; private set; }
        public IPlayer Owner { get; set; }
        public int Price { get; set; }
        public int Rent { get; set; }


        public Street(int index, string name, NeighbourhoodType neighbourhood, int price, int rent) : base(index, name)
        {
            this.NeighbourHood = NeighbourHood;
            this.Price = price;
            this.Rent = rent;
            this.Owner = null;
        }


        public override string ActOnPlayer(IPlayer player)
        {
            if (this.Owner == player)
            {
                return "You already Own";
            }
            else if (this.Owner == null)
            {
                return "Available";
            }
            else
            {
                player.DecrementMoney(this.Rent);
                this.Owner.IncrementMoney(this.Rent);
                return string.Format("you paid");
            }
        }



    }
}
