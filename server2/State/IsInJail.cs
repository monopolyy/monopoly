using server2.Models;
using server2.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.State
{
    public class IsInJail : PlayerState
    {
        public List<StrategyAlgo> actions { get; set; }

        public void addActions(List<StrategyAlgo> actionsList)
        {
            actions = actionsList;
        }

        public void handle(int index, Player play, Player OriginalPlayer, monopolisContext _context)
        {
            if (index == 1 || index == 2 || index == 10|| index ==9 ||index == 11 || index == 12)
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
