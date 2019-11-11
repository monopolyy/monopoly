using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Builder;
using server2.Facade;
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
            
            //  OriginalPlayer.Streets.Add(streett);
            // OriginalPlayer.MoneyP = OriginalPlayer.MoneyP - streett.Price;

            House house = new House(streett.Name,streett.Price,streett.Rent,streett.Level);
            
            if(streett.Level == 4)
            {
                HotelFacade facade = new HotelFacade();
                facade.CreateCompleteCar(house);
                streett.Level = 5;
                streett.Price = house.Price;
                streett.Rent = house.Billing;
            }
            else
            {
                streett.Level = streett.Level + 1;

            }

            return OriginalPlayer;
        }
    }
}
