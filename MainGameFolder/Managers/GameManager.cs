using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMono3.GameObjects;

namespace TryMono3.game.Managers
{
    class GameManager
    {
        private readonly BGManager _bgm = new();
        private InputManager _im = new();

        public GameManager(ContentManager content)
        {
            _bgm.AddLayer(new Layer(content.Load<Texture2D>("parallaxBackground/1"), 0.0f, 1f));
            _bgm.AddLayer(new Layer(content.Load<Texture2D>("parallaxBackground/2"), 0.1f, 1f));
            _bgm.AddLayer(new Layer(content.Load<Texture2D>("parallaxBackground/3"), 0.2f, 1f));
            _bgm.AddLayer(new Layer(content.Load<Texture2D>("parallaxBackground/4"), 0.3f, 1f));
        }

        public void Update()
        {
            _im.Update();
            _bgm.Update(_im.Movement);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _bgm.Draw(spriteBatch);
        }
    }
}
