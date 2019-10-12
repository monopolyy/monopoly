using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Monopoly2019.View.UI
{
    public class PlayerUI
    {
        public int Index { get; private set; }
        public Sprite Sprite { get; set; }

        public PlayerUI(Sprite sprite, int index)
        {
            this.Sprite = sprite;
            this.Index = index;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Sprite.Image, this.Sprite.Rectangle, Color.White);
        }
    }
}
