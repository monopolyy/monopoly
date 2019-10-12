using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Monopoly2019.View.UI
{
    public class TileOwnerNotification
    {
        public Sprite Sprite { get; set; }
        public bool IsActive { get; set; } = false;
        public int BoardIndex { get; private set; }
        public TileOwnerNotification(int index, Sprite sprite)
        {
            this.BoardIndex = index;
            this.Sprite = sprite;
        }
        public void SetOwner(ContentManager content, int ownerIndex)
        {
            this.IsActive = true;
            this.Sprite.Image = content.Load<Texture2D>("Owner" + ownerIndex.ToString());
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
            {
                spriteBatch.Draw(this.Sprite.Image, this.Sprite.Rectangle, Color.White);
            }
        }




    }
}
