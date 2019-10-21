using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model.Interfaces;
using Monopoly2019.Model;

namespace Monopoly2019.Model.Tiles
{
    public class Tax: Tile, ITile
    {
        public int TaxAmount { get; private set; }
        public Tax(int index, string name, int taxAmount) : base(index, name)
        {
            this.TaxAmount = taxAmount;
        }
        public override string ActOnPlayer(IPlayer player)
        {
            player.DecrementMoney(this.TaxAmount);
            return this.name + " " + this.TaxAmount;
        }
    }
}
