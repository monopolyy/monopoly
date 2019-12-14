﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;
using server2.Strategy;

namespace server2.State
{
    public class Parking : PlayerState
    {
        public List<StrategyAlgo> actions { get; set; }

        public void addActions(List<StrategyAlgo> actionsList)
        {
            actions = actionsList;
        }

        public void handle(int index, Player play, Player OriginalPlayer, monopolisContext _context)
        {
            actions[index].operation(play, OriginalPlayer, _context);
        }

        public void NextState(PlayerState state)
        {
            
        }
    }

  
}
