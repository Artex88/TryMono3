using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMono3.GameObjects;

namespace TryMono3.Managers
{
    class GameManager
    {
        private readonly BGManager _bgm = new();
        public GameManager(ContentManager content)        
        {
            _bgm.AddLayer(new Layer(content.Load<Texture2D>("parallaxBackground/bg"), 0.0f, 0.0f));
            _bgm.AddLayer(new Layer(content.Load<Texture2D>("parallaxBackground/buildings"), 0.1f, 0.2f));
            _bgm.AddLayer(new Layer(content.Load<Texture2D>("parallaxBackground/far-buildings"), 0.2f, 0.5f));
            _bgm.AddLayer(new Layer(content.Load<Texture2D>("parallaxBackground/skill-foreground"), 0.3f, 1.0f));
        }

        public void Update()
        {
            _bgm.Update(0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _bgm.Draw(spriteBatch);
        }
    }
}
