using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;
using server2.Decorator;

namespace server2.Strategy
{
    public class PayToOther : StrategyAlgo
    {
        public override Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {
           
            int pay = 0;
            int pos = player.CurrentPosition;
            var streett = _context.Street.First(st => st.Number == pos);
            if (streett.FkPlayeridPlayer == OriginalPlayer.IdPlayer)
            {
                return OriginalPlayer;
            }
            var anotherPlayer = _context.Player.First(pl => pl.IdPlayer == streett.FkPlayeridPlayer);

            if (streett.Level == 1)
            {
                pay = streett.Rent;
            }
            else
            {
                WholeStreet component = new Star(streett);
                for (int i = 0; i < streett.Level - 1; i++)
                {
                    if (i > 0)
                    {
                        component = new Star(component);
                    }
                }
                pay = component.GetCost();
            }



            OriginalPlayer.MoneyP = OriginalPlayer.MoneyP - pay;
            anotherPlayer.MoneyP = anotherPlayer.MoneyP + pay;

            return OriginalPlayer;
        }
    }
}
