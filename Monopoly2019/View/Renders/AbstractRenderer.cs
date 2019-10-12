using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Monopoly2019.View.Renders
{
    public abstract class AbstractRenderer
    {
        public abstract void DrawBoard();
        public abstract void ShowTileOwner(int playerIndex, int currentPlayerPosition);
        public abstract void MovePlayer(int index, int currentPosition, int newPosition);
    }
}
