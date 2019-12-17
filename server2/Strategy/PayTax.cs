using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;
namespace server2.Strategy
{
    public class PayTax :StrategyAlgo
    {
        public override Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {
            // OriginalPlayer.Turn = player.Turn;
            // return OriginalPlayer;
            int pos = player.CurrentPosition;
            var tax = _context.Tax.First(st => st.Number == pos);
            OriginalPlayer.MoneyP = OriginalPlayer.MoneyP - tax.TaxAmount;

            return OriginalPlayer;

        }
    }
}
