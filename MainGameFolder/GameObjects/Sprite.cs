using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMono3.Managers;
using TryMono3.Models;

namespace TryMono3.game.GameObjects
{
    public abstract class Sprite
    {
        protected Texture2D _texture;

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }
        }
        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);

        public abstract void SetAnimation();

        public abstract void Move();
    }
}
