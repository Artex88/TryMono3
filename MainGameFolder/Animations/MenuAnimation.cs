using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMono3.game.Managers;
using TryMono3.Models;

namespace TryMono3.game.Animations
{
    class MenuAnimation
    {
        private bool isStartAnimationEnd;
        private Color transparencyState;
        private int timeCounter;
        private AnimationManager _animationManager;

        public MenuAnimation(AnimationManager animationManager)
        {
            _animationManager = animationManager;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_animationManager._animation.IsTexturesCollection)
            {
                spriteBatch.Draw(_animationManager._animation.Textures[_animationManager._animation.CurrentFrame], new Vector2(0, 0), transparencyState);
            }
            else
                throw new Exception("This class work only with Textures sequences");
        }
        public void Update(GameTime gameTime)
        {
            if (isStartAnimationEnd == false)
            {
                transparencyState = Color.FromNonPremultiplied(255, 255, 255, timeCounter & 255);
                timeCounter++;
            }
            if (timeCounter == 255)
                isStartAnimationEnd = true;
            _animationManager.Update(gameTime);
        }
    }
}
