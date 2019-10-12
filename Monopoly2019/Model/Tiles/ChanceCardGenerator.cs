using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly2019.Model.Tiles
{
    public static class ChanceCardGenerator
    {

        private static readonly Random rng = new Random();
        private const int GO_POSITION = 0;
        private const int MAYFAIR_POSITION = 39;
        private const int BANK_MONEY_BONus = 100;
        private const int PRETTY_Bonus = 50;

        private static List<Func<Player, string>> listofChanceCards = new List<Func<Player, string>>
        {
        BankIsGivingYouMoney,
        YouArePretty,
        GiveAmountToOther
        };

        private static string BankIsGivingYouMoney(Player player)
        {
            player.IncrementMoney(BANK_MONEY_BONus);
            return "Bank is givving you 100";
        }

        private static string YouArePretty(Player player)
        {
            player.IncrementMoney(PRETTY_Bonus);
            return "You're pretty";
        }

        private static string GiveAmountToOther(Player player)
        {
            //Board.players[Board.CurrentPlayerIndex].DecrementMoney(30);
            // Board.players[(Board.CurrentPlayerIndex+1)%2].IncrementMoney(30);
            return "fun";
        }

        public static string GenerateRandomCard(Player player)
        {
            listofChanceCards = listofChanceCards.OrderBy(x => rng.Next()).ToList();
            Func<Player, string> randomChanceCard = listofChanceCards[rng.Next(0, 3)];

            return randomChanceCard.Invoke(player);
    }



    }
}
