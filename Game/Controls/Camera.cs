using Microsoft.Xna.Framework;
using TryMono3.GameObjects;
using TryMono3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMono3.Spritess;

namespace TryMono3.Controls
{
    public class Camera
    {

        public Matrix Transform { get; private set; }

        public void Follow(Player target)
        {
            Transform = Matrix.CreateTranslation(-target.Position.X - (target.Rectangle.Width / 2), -target.Position.Y - (target.Rectangle.Height / 2), 0) *
                    Matrix.CreateTranslation(Game1.ScreenWidth/2,Game1.ScreenHeight / 2, 0);
        }
    }
}
