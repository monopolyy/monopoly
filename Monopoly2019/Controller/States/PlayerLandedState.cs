using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model;
using Monopoly2019.Model.Tiles;
using Monopoly2019.View.UI;
using Microsoft.Xna.Framework.Input;

namespace Monopoly2019.Controller.States
{
    public class PlayerLandedState : State
    {

        public PlayerLandedState(State NextState) : base(NextState) { }


        public override void Execute()
        {
            int playerIndex = Board.CurrentPlayerIndex;
            var playerCurrentPosition = Board.players[playerIndex].CurrentPosition;
            Tile currentTile = Board.allTiles[playerCurrentPosition];
            EntryPoint.Game.renderer.NotificationText = "Player " + (playerIndex + 1) + " landed on\n" + currentTile.name + "\n";
            EntryPoint.Game.renderer.NotificationText += Board.allTiles[playerCurrentPosition].ActOnPlayer(Board.players[Board.CurrentPlayerIndex]);
            EntryPoint.Game.renderer.PlayerOneMoney = Board.players[0].money + "$";
            EntryPoint.Game.renderer.PlayerTwoMoney = Board.players[1].money + "$";

            ActivateEndTurnButton();

            if (currentTile is Street)
            {
                var currentTileAsStreet = currentTile as Street;
                if (currentTileAsStreet.Owner != Board.players[Board.CurrentPlayerIndex] && currentTileAsStreet.Owner == null)
                {
                    ActivateBuyButton(playerCurrentPosition);
                }
                else
                {
                    StateMachine.ChangeState();
                }

            }

            else if (currentTile is ChanceCard)
            {
                var currentTileAsChance = currentTile as ChanceCard;
                StateMachine.ChangeState();
            }

            else if (currentTile is SpecialTile)
            {
                var currentTileAsSpecial = currentTile as SpecialTile;
                if (currentTile.name == "Go To Jail")
                {
                    EntryPoint.Game.renderer.MovePlayer(Board.CurrentPlayerIndex, 30, 10);
                    Board.CurrentPlayerIndex = 10;
                }
            }

            else if (currentTile is Tax)
            {
                StateMachine.ChangeState();
            }
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
                EntryPoint.Game.renderer.NotificationText = "Are you sure you want to end your Turn?";

                StateMachine.ChangeState();
            }
        }


        private void ActivateBuyButton(int playerCurrentPosition)
        {
            Button buyButton = EntryPoint.Game.renderer.BuyButton;
            int currentPlayer = Board.CurrentPlayerIndex;
            bool mouseOverBuy = buyButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            if (mouseOverBuy)
            {
                buyButton.ChangeHoverImage();
            }
            else
            {
                buyButton.ChangeToInactiveImage();
            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverBuy)
            {
                buyButton.ChangeToClickedImage();
                EntryPoint.Game.renderer.NotificationText = "Property Bought!";
                Board.AddStreetToPlayer(playerCurrentPosition, currentPlayer);

                EntryPoint.Game.renderer.ShowTileOwner(currentPlayer, playerCurrentPosition);
                EntryPoint.Game.renderer.PlayerOneMoney = Board.players[0].money + "$";
                EntryPoint.Game.renderer.PlayerTwoMoney = Board.players[1].money + "$";

                StateMachine.ChangeState();
            }
        }
    }
}
