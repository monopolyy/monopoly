using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;
using server2.Strategy;

namespace server2.State
{
    public class IsBankrupt : PlayerState
    {
        public List<StrategyAlgo> actions { get; set ; }

        public void addActions(List<StrategyAlgo> actionsList)
        {
            this.actions = actionsList;
        }


        public void handle(int index, Player play, Player OriginalPlayer, monopolisContext _context)
        {
            if (index == 13)
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
