using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMono3.Managers;
using TryMono3.Models;

namespace TryMono3.Spritess
{
    public class Player : Sprite
    {
        #region Field

        protected AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animations;

        protected Vector2 _position;

        protected Texture2D _texture;

        public Vector2 Origin;

        #endregion

        #region Properties

        public Input Input;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }

        public new Rectangle Rectangle;

        public float Speed = 2f;

        public Vector2 Velocity;

        #endregion

        public Player(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
        }

        public Player(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, null, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("Not sprite");
        }

        public override void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X = Speed;
            }
        }

        public override void SetAnimation()
        {
            if (Velocity.X == 0 && Velocity.Y == 0)
                _animationManager.Play(_animations["stay"]);
            if (Velocity.X > 0)
                _animationManager.Play(_animations["walkright"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["walkleft"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["jump"]);
            if (Velocity.Y < 0)
                _animationManager.Play(_animations["jump"]);
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            SetAnimation();
            _animationManager.Update(gameTime);
            Position += Velocity;
            Velocity = Vector2.Zero;
        }
    }
}
