using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Strategy
{
    public class DropDices: StrategyAlgo
    {
        public override Player operation(Player player, Player OriginalPlayer)
        {

            OriginalPlayer.CurrentPosition = player.CurrentPosition;
            return OriginalPlayer;

        }
    }
}
