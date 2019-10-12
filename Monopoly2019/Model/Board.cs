using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model.Tiles;
using Monopoly2019.Model.Enums;

namespace Monopoly2019.Model
{
    public static class Board
    {
        public static List<Player> players;
        public static List<Tile> allTiles;
        public static int CurrentPlayerIndex;

        public static void InitializeBoard()
        {
            CurrentPlayerIndex = 0;
            players = new List<Player>()
            {
            new Player(1),
             new Player(2)
            };

            allTiles = new List<Tile>()
            {
            new SpecialTile(0, "GO!"),
            new Street(1, "astra", NeighbourhoodType.Brown,60,2),
             new ChanceCard(2, "CommunityChest"),
              new Street(3, "vectra", NeighbourhoodType.Brown,60,4),
             new Tax(4,"You are unlucky", 200),
             new Street(5, "techninė apžiūra", NeighbourhoodType.Station,200,25),
             new Street(6, "golf", NeighbourhoodType.Blue,80,6),
             new Street(7, "passat", NeighbourhoodType.Blue,80,6),
               new ChanceCard(2, "Chance Card"),
              new Street(9, "transporter", NeighbourhoodType.Blue,80,6),
              new SpecialTile(10, "Jail"),
               new Street(11,"Pall Mall",NeighbourhoodType.HotPink,140, 10),
                new Street(12,"Electric Company",NeighbourhoodType.Utility,150, 20),
                new Street(13,"Whitehall",NeighbourhoodType.HotPink,140, 10),
                new Street(14,"Northumberland Avenue",NeighbourhoodType.HotPink,160, 12),
                new Street(15,"Marylebone Station",NeighbourhoodType.Station, 200, 25),
                new Street(16,"Bow Street",NeighbourhoodType.Orange,180, 14),
                new ChanceCard(17,"Community Chest"),
                new Street(18,"Marlborough Street",NeighbourhoodType.Orange, 180, 14),
                new Street(19,"Vine Street",NeighbourhoodType.Orange, 200, 16),
                new SpecialTile(20,"Free Parking"),
                new Street(21,"Strand",NeighbourhoodType.Red, 220, 18),
                new ChanceCard(22,"Chance Card"),
                new Street(23,"Fleet Street",NeighbourhoodType.Red, 220, 18),
                new Street(24,"Trafalgar Square",NeighbourhoodType.Red, 240, 20),
                new Street(25,"Fenchurch Station",NeighbourhoodType.Station, 200, 25),
                new Street(26,"Leicester Square",NeighbourhoodType.Yellow, 260, 2),
                new Street(27,"Coventry Street",NeighbourhoodType.Yellow, 260, 2),
                new Street(28,"Water Works",NeighbourhoodType.Utility, 150, 2),
                new Street(29,"Picadilly",NeighbourhoodType.Yellow, 280, 2),
                new SpecialTile(30,"Go To Jail"),
                new Street(31,"Regent Street",NeighbourhoodType.Green, 300, 2),
                new Street(32,"Oxford Street",NeighbourhoodType.Green, 300, 2),
                new ChanceCard(33,"Community Chest"),
                new Street(34,"Bond Street",NeighbourhoodType.Green, 320, 25),
                new Street(35,"Liverpool Station",NeighbourhoodType.Station, 200, 2),
                new ChanceCard(36,"Chance Card"),
                new Street(37,"Park Lane",NeighbourhoodType.Purple, 350, 2),
                new Tax(38,"Super Tax",150),
                new Street(39,"Mayfair",NeighbourhoodType.Purple, 400, 2),
                };
        
        
        }
        public static void AddStreetToPlayer(int streetIndex, int playerIndex)
        {
            Street currentStreet = (Street)allTiles[streetIndex];
            currentStreet.Owner = players[playerIndex];

            players[playerIndex].streets.Add(currentStreet);
            players[playerIndex].DecrementMoney(currentStreet.Price);
        }

    }
}
