using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMono3.GameObjects;
using TryMono3.Models;

namespace TryMono3.Managers
{
    public class InputManager
    {
        private readonly float _speed = 200f;
        private Input _input = new();

        public float Movement { get; set; }

        public void Update()
        {
            var k = Keyboard.GetState();
            Movement = 0;
            if (k.IsKeyDown(Keys.D))
                Movement = -_speed;
            else if (k.IsKeyDown(Keys.A))
                Movement = _speed;
        }
    }
}
