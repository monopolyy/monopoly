using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Strategy
{
    public class UpdateLevel:StrategyAlgo
    {
        public override Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {

            int pos = OriginalPlayer.CurrentPosition;
            var streett = _context.Street.First(st => st.Number == pos);
            //var streett = controller.GetStreetByNum(pos);
            streett.Level = streett.Level + 1;
          //  OriginalPlayer.Streets.Add(streett);
           // OriginalPlayer.MoneyP = OriginalPlayer.MoneyP - streett.Price;

            return OriginalPlayer;
        }
    }
}
