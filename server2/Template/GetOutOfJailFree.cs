using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;
using server2.Strategy;
using server2.Template;

namespace server2.Template
{
    public class GetOutOfJailFree : GetOutOfJail
    {
        /*public override Player operation(Player player, Player OriginalPlayer, monopolisContext _context)
        {
            OriginalPlayer.State = 0;
            return OriginalPlayer;*/

        public override Player GetOutOfJailWhenPaid(Player player)
        {
            throw new NotImplementedException();
        }
        public override bool FreeEntrance()
        {
            return false;
        }
    }
}
