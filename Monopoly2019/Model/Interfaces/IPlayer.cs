using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model.Tiles;

namespace Monopoly2019.Model.Interfaces
{
    public interface IPlayer
    {
        int CurrentPosition { get; }
        int index { get; }
        bool isInJail { get; }
        int money { get; }
        void setPosition(int newposition);
        List<Street> streets { get; }
        void DecrementMoney(int amount);
        void IncrementMoney(int amount);
    }
}
