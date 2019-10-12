using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model.Interfaces;

namespace Monopoly2019.Model.Tiles
{
    class SpecialTile :Tile, ITile
    {

        public SpecialTile(int index, string name) : base(index, name)
        {
            
        }

        public override string ActOnPlayer(Player player)
        {
            if (this.Index == 10)
            {
                return "You are visiting your friend in jail";
            }
            else if (this.Index == 20)
            {
                return "You are in parking";
            }
            else if (this.Index == 30)
            {
                return "You are in jail";
            }
            return null;
        }
    }
}
