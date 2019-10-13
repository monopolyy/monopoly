using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model;

namespace Monopoly2019.Controller.States
{
    public class PlayerRollState : State
    {

        private Random rng;
        public PlayerRollState(State nextState) : base(nextState)
        {
            this.rng = new Random();
        }
        public override void Execute()
        {
            int currentPlayerPosition = Board.players[Board.CurrentPlayerIndex].CurrentPosition;

            int firstDiceNumber = rng.Next(1, 7);
            int secondDiceNumber = rng.Next(1, 7);
            int totalPositionToMove = firstDiceNumber + secondDiceNumber;


            PlayerMoveState.PlayerOldPosition = currentPlayerPosition;    
            EntryPoint.Game.renderer.FirstDice.ChangeDiceImage(firstDiceNumber);
            EntryPoint.Game.renderer.SecondDice.ChangeDiceImage(secondDiceNumber);
            EntryPoint.Game.renderer.NotificationText = "Player " + Board.CurrentPlayerIndex + 1 + " rolled " + totalPositionToMove;
            Board.players[Board.CurrentPlayerIndex].setPosition(currentPlayerPosition + totalPositionToMove);

            StateMachine.ChangeState();
        }
    }
}
