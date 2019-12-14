﻿using System;
using System.Collections.Generic;
using server2.Strategy;
using server2.Observer;
using server2.State;
//using server2.Adapter;

namespace server2.Models
{
    public partial class Player : IObserver
    {
        /*public Player(string name, int currentposition, int indexp, bool isinjail, int turn, int moneyp, int idplayer,
            ICollection<Street> streets, List<StrategyAlgo> actions, StrategyAlgo activestrategy)
        {

        }*/
        public string Name { get; set; }
        public int CurrentPosition { get; set; }
        public int IndexP { get; set; }
        public int State { get; set; }
        public int Turn { get; set; }
        public int MoneyP { get; set; }
        public int IdPlayer { get; set; }

        public ICollection<Street> Streets { get; set; }

        private  List<StrategyAlgo> actions = new List<StrategyAlgo>();

        PlayerState normalState = new Normal();
        
        PlayerState JailState = new IsInJail();
        PlayerState ParkingState = new Parking();
        PlayerState isBankrupt = new IsBankrupt();

        PlayerState currentState;
        public Player()
        {
            Streets = new HashSet<Street>();
            addStrategy(new BuyStreet());  //0
            addStrategy(new DropDices());  //1
            addStrategy(new EndTurn());    //2
            addStrategy(new PayToOther()); //3
            addStrategy(new PayTax());     //4
            addStrategy(new PassedGo());   //5
            addStrategy(new UpdateLevel());   //6
            addStrategy(new Chance());   //7
            addStrategy(new Cummunity());   //8
            addStrategy(new GoToJail());   //9
            addStrategy(new GetOutOfJail());//10   
            addStrategy(new hasBankrupted());//11   

            normalState.addActions(actions);
            JailState.addActions(actions);
            ParkingState.addActions(actions);
            isBankrupt.addActions(actions);
            currentState = normalState;

        }
        private void addStrategy(StrategyAlgo s)
        {
            this.actions.Add(s);
        }
         public void Act(int index, Player play, monopolisContext _context)
        {
           actions[index].operation(play, this, _context);
        }

        public Player GetState(int index, Player play, monopolisContext _context)
        {            
            if (index ==9 )
            {
                currentState = JailState;
                this.State = 1;
            }
            if (index == 10)
            {
                currentState = normalState;
                this.State = 0;
            }
            if (this.MoneyP <-100)
            {
                currentState = isBankrupt;
                this.State = 0;
            }
            currentState.handle(index, play,this, _context);

            return this;
        }

        public void Update(IStreet street)
        {
            Console.WriteLine("Player: {0} was notified about street {1} owner changes", this.Name, (street as Street).Name);
        }

    }
}
