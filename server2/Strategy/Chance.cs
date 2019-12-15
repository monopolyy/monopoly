using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Memento;
using server2.Models;

namespace server2.Strategy
{
    public class Chance : StrategyAlgo
    {
        //IndexT =0
        public override Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {
            var ChanceList = _context.Tile.Where(tl => tl.DrawOut == 0 && tl.IndexT == 0).ToList();
            var rand = new Random();
            var chanceCard = ChanceList[rand.Next(ChanceList.Count)];

            if (chanceCard.Amaunt==0)
            {
                //kreiptis dėl pozicijos

                MementoPattern restoreState= Data.careTakers.get(Data.careTakers.getListCount() - 3);
                OriginalPlayer.restoreState(restoreState);

            }
            else { 
           
            OriginalPlayer.MoneyP = OriginalPlayer.MoneyP + chanceCard.Amaunt;
            }
            var TileToChange = _context.Tile.First(tl => tl.IdTile == chanceCard.IdTile);
            TileToChange.DrawOut = 1;
           
            //var chance = _context.Player.First(pl => pl.IdPlayer == streett.FkPlayeridPlayer);
            return OriginalPlayer;
        }
    }
}
