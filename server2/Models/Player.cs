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
            addStrategy(new BuyStreet());  //0
            addStrategy(new DropDices());  //1
            addStrategy(new EndTurn());    //2
            addStrategy(new PayToOther()); //3
            addStrategy(new PayTax());     //4
            addStrategy(new PassedGo());   //5
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
         public void Act(int index, Player play, monopolisContext _context)
        {
           actions[index].operation(play, this, _context);
        }

    }
}
