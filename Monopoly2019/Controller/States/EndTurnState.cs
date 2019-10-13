using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model;
using Monopoly2019.View.UI;
using Microsoft.Xna.Framework.Input;

namespace Monopoly2019.Controller.States
{
   public class EndTurnState: State
    {
        public EndTurnState(State nextState)
           : base(nextState) { }

        public override void Execute()
        {
            EntryPoint.Game.renderer.PlayerOneMoney = Board.players[0].money + "$";
            EntryPoint.Game.renderer.PlayerTwoMoney = Board.players[1].money + "$";
            ActivateEndTurnButton();
        }
        private void ActivateEndTurnButton()
        {
            Button endTurnButton = EntryPoint.Game.renderer.EndTurnButton;

            bool mouseOverendTurn = endTurnButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            if (mouseOverendTurn)
            {
                endTurnButton.ChangeHoverImage();
            }
            else
            {
                endTurnButton.ChangeToInactiveImage();
            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverendTurn)
            {
                endTurnButton.ChangeToClickedImage();
                Board.CurrentPlayerIndex = (Board.CurrentPlayerIndex + 1) % 2;
                StateMachine.ChangeState();
            }
        }
    }

}

