using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TryMono3.Controls;
using TryMono3.Managers;
using TryMono3.Models;

namespace TryMono3.States
{
    public class MenuState : State
    {
        private List<Controls.Component> _components;

        private static MenuAnimation _menuAnimation;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

            var startButtonTexture = _content.Load<Texture2D>("Buttons/startbutton");
            var quitButtonTexture = _content.Load<Texture2D>("Buttons/exitbutton");
            var font = _content.Load<SpriteFont>("File");
            var backgroundTextures = new List<Texture2D>()
            {
                content.Load<Texture2D>("menuAnimation\\0"),
                content.Load<Texture2D>("menuAnimation\\1"),
                content.Load<Texture2D>("menuAnimation\\2"),
                content.Load<Texture2D>("menuAnimation\\3"),
                content.Load<Texture2D>("menuAnimation\\4"),
                content.Load<Texture2D>("menuAnimation\\5"),
                content.Load<Texture2D>("menuAnimation\\6"),
                content.Load<Texture2D>("menuAnimation\\7"),
                content.Load<Texture2D>("menuAnimation\\8"),
                content.Load<Texture2D>("menuAnimation\\9"),
                content.Load<Texture2D>("menuAnimation\\10"),
                content.Load<Texture2D>("menuAnimation\\11"),
                content.Load<Texture2D>("menuAnimation\\12"),
                content.Load<Texture2D>("menuAnimation\\13"),
                content.Load<Texture2D>("menuAnimation\\14"),
            };

            var backgroundAnimation = new AnimationManager(new Animation(backgroundTextures));
            _menuAnimation = new MenuAnimation(backgroundAnimation);

            

            var newGameButton = new Controls.Button(startButtonTexture, font)
            {
                Position = new Vector2(490, 200),
                Text = "",
            };
                newGameButton.Click += NewGameButton_Click;

            var quitButton = new Controls.Button(quitButtonTexture, font)
            {
                Position = new Vector2(580, 250),
                Text = "",
            };

                quitButton.Click += QuitButton_Click;
            

            _components = new List<Controls.Component>()
            {
                newGameButton,
                quitButton,
            };
            
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var menuTexture = _content.Load<Texture2D>("Buttons/menubutton");
            var ramka = _content.Load<Texture2D>("Buttons/ramka");
            spriteBatch.Begin();

            _menuAnimation.Draw(spriteBatch);

            spriteBatch.Draw(menuTexture, new Vector2(565, 70), Color.White);

            spriteBatch.Draw(ramka, new Vector2(460, 120), Color.White);

            foreach (var component in _components)
                component.Draw(gameTime,spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // если спрайты не нужны удаляем
        }

        public override void Update(GameTime gameTime)
        {

            _menuAnimation.Update(gameTime);
            

            foreach (var component in _components)
                component.Update(gameTime);
        }
    }
}
