using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model.Interfaces;
using Monopoly2019.Model.Tiles;

namespace Monopoly2019.Model
{
    public class ConcretePlayerFactory : PlayerFactory
    {
        public override IPlayer GetPlayer()
        {
            Board.numberOfPlayers = Board.numberOfPlayers + 1;
            int newPlayerIndex = Board.numberOfPlayers;
            return new Player(newPlayerIndex);
        }
    }
}
