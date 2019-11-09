using System;
using System.Collections.Generic;
using server2.Strategy;

namespace server2.Models
{
    public partial class Player
    {
        public Player()
        {
            Streets = new HashSet<Street>();
            addStrategy(new BuyStreet());
            addStrategy(new DropDices());
            addStrategy(new EndTurn());
        }

        public string Name { get; set; }
        public int CurrentPosition { get; set; }
        public int IndexP { get; set; }
        public bool IsInJail { get; set; }
        public int Turn { get; set; }
        public int MoneyP { get; set; }
        public int IdPlayer { get; set; }

        public ICollection<Street> Streets { get; set; }

        private  List<StrategyAlgo> actions = new List<StrategyAlgo>();

        private StrategyAlgo activeStrategy;
        private void addStrategy(StrategyAlgo s)
        {
            this.actions.Add(s);
        }
         public void Act(int index, Player play)
        {
           actions[index].operation(play, this);
        }

    }
}
