﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;
using server2.Strategy;

namespace server2.State
{
    public class Normal : PlayerState
    {
    
        public List<StrategyAlgo> actions { get ; set ; }

        public void addActions(List<StrategyAlgo> actionsList)
        {
            actions = actionsList;
        }

        public void handle(int index, Player play,Player OriginalPlayer, monopolisContext _context)
        {
            if (index == 0 || index == 1 || index == 2 || index == 3||index ==4||index == 5 || index == 6 || index == 7 || index == 8 || index == 9)
            {
                actions[index].operation(play, OriginalPlayer, _context);
            }
           
          
        }

        public void NextState(PlayerState state)
        {
            throw new NotImplementedException();
        }
    }
}
