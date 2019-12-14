using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Strategy
{
    public class GetOutOfJail : StrategyAlgo
    {
        public override Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {
            OriginalPlayer.MoneyP = OriginalPlayer.MoneyP - 50;
            OriginalPlayer.State = 0;
            return OriginalPlayer;
        }
    }
}
