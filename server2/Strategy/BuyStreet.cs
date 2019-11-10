using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;
using server2.Controllers;

namespace server2.Strategy
{
   
    public class BuyStreet : StrategyAlgo
    {
        //private readonly monopolisContext _context;
     //   StreetsController controller = new StreetsController(_context);
        public override Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {
            int pos = OriginalPlayer.CurrentPosition;
           var streett = _context.Street.First(st => st.Number == pos);
          //var streett = controller.GetStreetByNum(pos);
            streett.FkPlayeridPlayer = OriginalPlayer.IdPlayer;
            OriginalPlayer.Streets.Add(streett);
            OriginalPlayer.MoneyP = OriginalPlayer.MoneyP - streett.Price;
          
            return OriginalPlayer;
        }
    }
}
