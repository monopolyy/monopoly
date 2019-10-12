using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model;

namespace Monopoly2019.Controller.States
{
   public class InitialState: State
    {

        public InitialState(State nextState) : base(nextState)
        { 
        
        }

        public override void Execute()
        {
            Board.InitializeBoard();
        }
    }
}
