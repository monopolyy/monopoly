using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model.Interfaces;
using Monopoly2019.Model;

namespace Monopoly2019.Model.Tiles
{
   public abstract class Tile :ITile
    {
        public Tile(int index, string name)
        {
            this.Index = index;
            this.name = name;
        }

        public int Index { get; private set; }
        public string name { get; private set; }

        public abstract string ActOnPlayer(IPlayer player);

    }
}
