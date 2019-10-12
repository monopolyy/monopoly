using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model.Interfaces;
using Monopoly2019.Model.Tiles;


namespace Monopoly2019.Model
{
    public class Player : IPlayer
    {

        public const int Initial_Player_Money = 1500;
        public const int Total_number_of_tiles = 40;
        public int CurrentPosition { get; private set; } = 0;
        public int index { get; private set; } = 0;
        public bool isInJail { get; private set; } = false;
        public int money { get; private set; } = Initial_Player_Money;

        public List<Street> streets {get; private set;} = new List<Street>();
        public Player(int index)
        {

            this.index = index;
        }
        public void setPosition(int newposition)
        {
            int modifiedPosition = newposition;

            if (modifiedPosition < 0)
            {
                modifiedPosition += Total_number_of_tiles;
            }
            if (modifiedPosition >= Total_number_of_tiles)
            {
                modifiedPosition = modifiedPosition - Total_number_of_tiles;
                this.IncrementMoney(200);
            }
            this.CurrentPosition = modifiedPosition;
        }


        public void IncrementMoney(int amount)
        {
            this.money += amount;
        }
        public void DecrementMoney(int amount)
        {
            this.money -= amount;
        }
    }
}
