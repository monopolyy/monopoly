using server2.Models;
using server2.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.State
{
  public interface PlayerState
    {
        List<StrategyAlgo> actions { get; set; }
        void handle(int index, Player play, Player OriginalPlayer, monopolisContext _context);
        void NextState(PlayerState state);

        void addActions(List<StrategyAlgo> actionsList);

    }
}
