using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Controller.States;

namespace Monopoly2019.Controller
{
    public static class StateMachine
    {
        public static State CurrentState;
        public static Dictionary<string, State> States = new Dictionary<string, State>();
        private static PlayerTurnState playerTurnState;
        private static InitialState initialstate;
        public static void Initialize()
        {
            playerTurnState = new PlayerTurnState(initialstate);
            initialstate = new InitialState(playerTurnState);
            playerTurnState.NextState = initialstate;
            States.Add("InitialState", initialstate);
        }

        public static void ChangeState()
        {
            CurrentState = CurrentState.NextState;
        }
    }
}
