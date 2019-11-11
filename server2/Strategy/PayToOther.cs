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
            if (streett.Number ==5 || streett.Number == 15 || streett.Number == 25 || streett.Number == 35 ) {
                int count = _context.Street.Where(st => st.NeighbourHood == 9 && st.FkPlayeridPlayer == anotherPlayer.IdPlayer).Count();
                if (count == 1)
                {
                    pay = streett.Rent;
                }
                else {
                    WholeStreet component = new StationsDecorate(streett);
                    for (int i = 0; i < count - 1; i++)
                    {
                        if (i > 1)
                        {
                            component = new StationsDecorate(component);
                        }
                    }
                    pay = component.GetCost();
                }
            }
            else { if (streett.Level == 1)
                {
                    pay = streett.Rent;
                }
                else
                {
                    WholeStreet component = new Star(streett);
                    for (int i = 0; i < streett.Level - 1; i++)
                    {
                        if (i ==2)
                        {
                            component = new Star2nd(component);
                        }
                        else if (i>2) {
                            component = new Star3rd(component);
                        }
                    }
                    pay = component.GetCost();
                } }



            OriginalPlayer.MoneyP = OriginalPlayer.MoneyP - pay;
            anotherPlayer.MoneyP = anotherPlayer.MoneyP + pay;

            return OriginalPlayer;
        }
    }
}
