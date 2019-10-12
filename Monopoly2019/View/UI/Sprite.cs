using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monopoly2019.View.UI
{
   public class Sprite
    {
        public Rectangle Rectangle;
        public Texture2D Image { get; set; }
        public Sprite(Rectangle rectangle, Texture2D image)
        {
            this.Rectangle = rectangle;
            this.Image = image;
        }
        
    }
}
