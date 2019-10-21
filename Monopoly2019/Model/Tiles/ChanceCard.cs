using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model.Interfaces;

namespace Monopoly2019.Model.Tiles
{
    class ChanceCard :Tile, ITile
    {
        public ChanceCard(int index, string name) : base(index, name)
        {

        }
        public override string ActOnPlayer(IPlayer player)
        {
            //return ChanceCardGenerator.GenerateRandomCard(player);
            return null;
        }
    }
}
