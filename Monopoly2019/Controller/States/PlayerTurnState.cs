using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.View.UI;
using Monopoly2019.Model;
using Microsoft.Xna.Framework.Input;

namespace Monopoly2019.Controller.States
{
    public class PlayerTurnState : State
    {

        public PlayerTurnState(State nextState) : base(nextState) { }
        public override void Execute()
        {
            Button rollButton = EntryPoint.Game.renderer.RollButton;
            EntryPoint.Game.renderer.NotificationText = "Player" + (Board.CurrentPlayerIndex + 1) + "'s turn";
            bool mouseOverToll = rollButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            if (mouseOverToll)
            {
                rollButton.ChangeHoverImage();
            }
            else {
                rollButton.ChangeToInactiveImage();
            
            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverToll)
            {
                rollButton.ChangeToClickedImage();
                EntryPoint.Game.renderer.ShouldPlayerMove = true;
                StateMachine.ChangeState();
            }
        }  
    }
}
