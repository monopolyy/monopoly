using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;

namespace server2.Visitor
{
    public class PlayerMoneyVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Player player = element as Player;

            player.MoneyP += 500;


        }
    }
}
