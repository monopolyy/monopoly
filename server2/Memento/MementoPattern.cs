using server2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Memento
{
    public class MementoPattern
    {
        private int indexPlayer;
        private int position;

      public MementoPattern(int indexPlayer, int position)
        {
            this.indexPlayer = indexPlayer;
            this.position = position;
        }
        public void Restore(Player player)
        {
            if (player.IndexP== indexPlayer)
            {
                player.SetPosition(this.position);
            }
        }






    }
}
