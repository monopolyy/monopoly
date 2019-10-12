using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monopoly2019.View.UI
{
    public class Dice
    {
        public Sprite Sprite { get; set; }
        private Texture2D[] valueSprites = new Texture2D[6];

        public Dice(Sprite sprite, Texture2D[] valueSprites)
        {
            this.Sprite = sprite;
            this.valueSprites = valueSprites;
        }
        public void ChangeDiceImage(int diceValue)
        {
            this.Sprite.Image = this.valueSprites[diceValue - 1];
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Sprite.Image, this.Sprite.Rectangle, Color.White);
        }

    }
}
