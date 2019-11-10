using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Strategy
{
    public class PayToOther : StrategyAlgo
    {
        public override Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {
            int pos = player.CurrentPosition;
            var streett = _context.Street.First(st => st.Number == pos);
            if (streett.FkPlayeridPlayer == OriginalPlayer.IdPlayer)
            {
                return OriginalPlayer;
            }
            var anotherPlayer = _context.Player.First(pl => pl.IdPlayer == streett.FkPlayeridPlayer);
            OriginalPlayer.MoneyP = OriginalPlayer.MoneyP - streett.Rent;
            anotherPlayer.MoneyP = anotherPlayer.MoneyP + streett.Rent;

            return OriginalPlayer;
        }
    }
}
