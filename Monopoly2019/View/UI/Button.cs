using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monopoly2019.View.UI
{
    public class Button
    {
        public Sprite Sprite {get; set;}
        public Texture2D hoverImage { get; set; }
        public Texture2D clickedImage { get; set; }
        public Texture2D inactiveImage { get; set; }
        public Button(Sprite sprite, Texture2D hoverimage, Texture2D clickedImage, Texture2D inactiveImage)
        {
            this.Sprite = sprite;
            this.hoverImage = hoverimage;
            this.clickedImage = clickedImage;
            this.inactiveImage = inactiveImage;
        }

        public void ChangeHoverImage()
        {
            this.Sprite.Image = this.hoverImage;
        }
        public void ChangeToClickedImage()
        {
            this.Sprite.Image = this.clickedImage;
        }
        public void ChangeToInactiveImage()
        {
            this.Sprite.Image = this.inactiveImage;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Sprite.Image, this.Sprite.Rectangle, Color.White);
        }
    }
}
