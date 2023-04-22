using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using TryMono3.Models;
using TryMono3.Managers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TryMono3.Spritess
{
    public class Sprite
    {
        #region Field

        protected AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animations;

        protected Vector2 _position;

        protected Texture2D _texture;

        private float _rotation;

        public Vector2 Origin;

        public float RotationVelocity = 3f;

        public float LinearVelocity = 4f;

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

        public float Speed = 2f;

        public Vector2 Velocity;

        #endregion

        #region Methods
        public Sprite(Texture2D texture, Vector2 position)
        {
            _texture = texture;
        }

        public Sprite(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
            spriteBatch.Draw(_texture, Position,null, Color.White, _rotation, Origin, 1, SpriteEffects.None, 0f);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("Not sprite");
        }

        public virtual void Move()
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
                _rotation -= MathHelper.ToRadians(RotationVelocity);
                Velocity.X = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                _rotation += MathHelper.ToRadians(RotationVelocity);
                Velocity.X = Speed;
            }
        }

        public void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            SetAnimations();

            _animationManager.Update(gameTime);
            Position += Velocity;
            Velocity = Vector2.Zero;

        }

        protected virtual void SetAnimations()
        {
            if (Velocity.X == 0 && Velocity.Y == 0)
            {
                _animationManager.Play(_animations["stay"]);
            }
            if (Velocity.X > 0)
                _animationManager.Play(_animations["walk"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["walk"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["jump"]);         
            if (Velocity.Y < 0)
                _animationManager.Play(_animations["jump"]);
        }
        #endregion

    }
}
