using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server2.Models;
namespace server2.Visitor
{
    class Players
    {
        private List<Player> _players = new List<Player>();

        public void Attach(Player player)
        {
            _players.Add(player);
        }
        public void Detach(Player player)
        {
            _players.Remove(player);
        }
        public void Accept(IVisitor visitor)
        {
            foreach (Player e in _players)
            {
                e.Accept(visitor);
            }
        }

    }
}
