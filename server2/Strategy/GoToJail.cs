using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Strategy
{
    public class GoToJail : StrategyAlgo
    {
        public override Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {
            if (OriginalPlayer.State == 0|| OriginalPlayer.State == 2)
            {
                OriginalPlayer.State = 1;
                OriginalPlayer.CurrentPosition = 10;
            }
            else {
                OriginalPlayer.State = 0;
            }
            

            return OriginalPlayer;
        }
    }
}
