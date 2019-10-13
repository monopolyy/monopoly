using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model;

namespace Monopoly2019.Controller.States
{
    public class PlayerMoveState:State
    {

        public static int PlayerOldPosition { get; set; }

        public PlayerMoveState(State nextState) : base(nextState) { }

        public override void Execute()
        {
            EntryPoint.Game.renderer.MovePlayer(Board.CurrentPlayerIndex, PlayerOldPosition, Board.players[Board.CurrentPlayerIndex].CurrentPosition);
            if (!EntryPoint.Game.renderer.ShouldPlayerMove)
            {
                StateMachine.ChangeState();
            }
        }
    }
}
