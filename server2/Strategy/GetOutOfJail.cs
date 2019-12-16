using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;
using server2.Strategy;

namespace server2.Strategy
{
    public abstract class GetOutOfJail : StrategyAlgo
    {
        public override sealed Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {
            if (FreeEntrance())
            {
                OriginalPlayer = GetOutOfJailWhenPaid(OriginalPlayer);
            }
            


        //    OriginalPlayer.MoneyP = OriginalPlayer.MoneyP - 50;
            OriginalPlayer.State = 0;
            return OriginalPlayer;
        }
     //   public abstract Player GetOutOfJailForFree(Player player);
        public abstract Player GetOutOfJailWhenPaid(Player player);
        public abstract bool FreeEntrance();
    }
}
