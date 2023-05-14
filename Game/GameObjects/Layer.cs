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

        private Vector2 _position2;

        private Vector2 _position3;

        private readonly float _depth;

        private readonly float _moveScale;

        public Layer(Texture2D texture, float depth, float moveScale)
        {
            _texture = texture;
            _position = Vector2.Zero;
            _position2 = Vector2.Zero;
            _position3 = Vector2.Zero;
            _depth = depth;
            _moveScale = moveScale;
        }

        public void Update(float movement)
        {
            _position.X += movement * _moveScale * Globals.ElapsedSeconds;
            _position2.X = movement * _moveScale * Globals.ElapsedSeconds * 2;
            _position3.X = movement * _moveScale * Globals.ElapsedSeconds * 2;
            _position.X %= _texture.Width;

            if (_position.X >= 0)
            {
                _position2.X = (_position.X - _texture.Width);
                _position3.X = (_position.X + _texture.Width);
            }
            else
            {
                _position2.X = (_position.X + _texture.Width);
                _position3.X = (_position.X - _texture.Width);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, _depth);
            spriteBatch.Draw(_texture, _position2, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, _depth);
            spriteBatch.Draw(_texture, _position3, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, _depth);
        }
    }
}
