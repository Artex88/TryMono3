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
using TryMono3.game.Animations;
using TryMono3.game.Models;
using TryMono3.Managers;

namespace TryMono3.game.States
{
    public class MenuState : State
    {
        private List<Controls.Component> _components;

        private List<NonInteractiveElement> _environment;

        private static MenuAnimation _menuAnimation;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
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



            var newGameButton = new Controls.Button(_content.Load<Texture2D>("Buttons/startbutton"), null)
            {
                Position = new Vector2(730, 330),
            };
            newGameButton.Click += NewGameButton_Click;

            var quitButton = new Controls.Button(_content.Load<Texture2D>("Buttons/exitbutton"), null)
            {
                Position = new Vector2(820, 380),
            };

            quitButton.Click += QuitButton_Click;


            _components = new List<Controls.Component>()
            {
                newGameButton,
                quitButton,
            };

            _environment = new List<NonInteractiveElement>()
            {
                new NonInteractiveElement(_content.Load<Texture2D>("Buttons/menubutton"),  new Vector2(810, 235)),
                new NonInteractiveElement(_content.Load<Texture2D>("Buttons/ramka"), new Vector2(700, 280)),
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
            spriteBatch.Begin();
            _menuAnimation.Draw(spriteBatch);
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
            foreach (var element in _environment)
                element.Draw(gameTime, spriteBatch);
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
