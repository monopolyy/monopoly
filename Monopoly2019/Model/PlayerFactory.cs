using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model.Interfaces;
using Monopoly2019.Model.Tiles;

namespace Monopoly2019.Model
{
    public abstract class PlayerFactory
    {
        public abstract IPlayer GetPlayer();
    }
}
