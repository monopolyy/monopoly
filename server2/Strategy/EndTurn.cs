﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Strategy
{
    public class EndTurn : StrategyAlgo
    {
        public override Player operation(Player player, Player OriginalPlayer)
        {
            OriginalPlayer.Turn = player.Turn;
            return OriginalPlayer;
           // return player;

        }
    }
}