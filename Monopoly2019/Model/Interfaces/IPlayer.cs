using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly2019.Model.Interfaces
{
    public interface IPlayer
    {
         int CurrentPosition { get; }
         int index { get; }
        bool isInJail { get; }
        int money { get; }
        void setPosition(int newposition);
    }
}
