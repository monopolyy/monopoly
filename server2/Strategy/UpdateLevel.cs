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
        House housePattern = new House();
        public override Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {

            int pos = OriginalPlayer.CurrentPosition;
            var streett = _context.Street.First(st => st.Number == pos);
            //var streett = controller.GetStreetByNum(pos);

            //  OriginalPlayer.Streets.Add(streett);
            // OriginalPlayer.MoneyP = OriginalPlayer.MoneyP - streett.Price;

            //House house = new House(streett.Name,streett.Price,streett.Rent,streett.Level);
            House house = housePattern.DeepCopy(streett.Name, streett.Price, streett.Rent, streett.Level);
            Console.WriteLine("{0} {1} {2} {3}", house.Name, house.Price, house.Billing, house.NumberOfHouses);
            
            if(streett.Level == 4)
            {
                HotelFacade facade = new HotelFacade();
                facade.CreateCompleteCar(house);
                streett.Level = 5;
                streett.Price = house.Price;
                streett.Rent = house.Billing;
            }
            else if (streett.Level == 0)
            {
                HouseBuilder builder;
                HouseBuildDirector director = new HouseBuildDirector();

                builder = new ConcreteHouseBuilder(house);
                director.Construct(builder);
                streett.Level = builder.House.NumberOfHouses;
                //streett.Level = 1;
            }
            else
            {
                streett.Level = streett.Level + 1;

            }

            return OriginalPlayer;
        }
    }
}
