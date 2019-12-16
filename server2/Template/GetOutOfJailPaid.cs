using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;
using server2.Strategy;

namespace server2.Template
{
    public class GetOutOfJailPaid : GetOutOfJail
    {
        public override bool FreeEntrance()
        {
            return true;
        }

        public override Player GetOutOfJailWhenPaid(Player player)
        {
            player.MoneyP = player.MoneyP - 50;
            return player;
        }
    }
}
