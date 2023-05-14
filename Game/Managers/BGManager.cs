using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMono3.GameObjects;

namespace TryMono3.Managers
{
    class BGManager
    {
        private readonly List<Layer> _layers;

        public BGManager()
        {
            _layers = new();
        }

        public void AddLayer(Layer layer)
        {
            _layers.Add(layer);
        }
        public void Update(float movement)
        {
            foreach (var layer in _layers)
            {
                layer.Update(movement);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var layer in _layers)
            {
                layer.Draw(spriteBatch);
            }
        }
    }
}
