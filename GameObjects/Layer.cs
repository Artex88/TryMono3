using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryMono3.GameObjects
{
    public class Layer
    {
        private readonly Texture2D _texture;

        private Vector2 _position;

        private readonly float _depth;

        private readonly float _moveScale;

        public Layer(Texture2D texture, float depth, float moveScale)
        {
            _texture = texture;
            _position = Vector2.Zero;
            _depth = depth;
            _moveScale = moveScale;
        }

        public void Update(float movement)
        {
            _position.X += movement * _moveScale * Globals.ElapsedSeconds;
            _position.X %= _texture.Width;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position,null, Color.White,0,Vector2.Zero, Vector2.One, SpriteEffects.None,_depth);
        }
    }
}
