using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryMono3.game.Models
{
    public class NonInteractiveElement
    {
        private Texture2D _texture;

        private Vector2 _position;

        public NonInteractiveElement(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //
        }
    }
}
