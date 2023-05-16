using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMono3.Spritess;
using TryMono3.Models;
using TryMono3.Managers;
using TryMono3.Controls;
using TryMono3.Map;

namespace TryMono3.States
{
    class GameState : State
    {
        private List<Sprite> _sprites;

        private GameManager _gm;

        private Camera _camera;

        private Player _player;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _sprites = new List<Sprite>();
            var playerAnimations = new Dictionary<string, Animation>()
            {
                {"walkright", new Animation(content.Load<Texture2D>("sprites/WalkRight"), 5)},
                {"walkleft", new Animation(content.Load<Texture2D>("sprites/WalkLeft"), 5)},
                {"jump", new Animation(content.Load<Texture2D>("sprites/jump"), 3) },
                {"stay", new Animation(content.Load<Texture2D>("sprites/stay"), 1 )}
            };
            _player = new Player(playerAnimations)
            {
                Position = new Vector2(200, 400),
                Input = new Input()
                {
                    Up = Keys.W,
                    Right = Keys.D,
                    Left = Keys.A,
                    Down = Keys.S,
                }
            };

            _camera = new Camera();
            _gm = new(content);

            
            _sprites.Add(_player);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: _camera.Transform);
            _gm.Draw(spriteBatch);
            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //
        }

        public override void Update(GameTime gameTime)
        {
            _gm.Update();
            foreach(var sprite in _sprites) 
            {
                sprite.Update(gameTime);
            }
            _camera.Follow(_player);
        }
    }
}
