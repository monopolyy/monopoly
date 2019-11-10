﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Strategy
{
    public class PassedGo : StrategyAlgo
    {
        public override Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {
           
            OriginalPlayer.MoneyP = OriginalPlayer.MoneyP + 200;

            return OriginalPlayer;
        }
    }
}
