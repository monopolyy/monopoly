using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Monopoly2019.Model;
using Monopoly2019.Controller;
using Microsoft.Xna.Framework.Input;
using Monopoly2019.View.Renders;
using Monopoly2019;

namespace Monopoly2019.Controller
{
    public class MonopolyGame : Game // Singleton
    {
        private static MonopolyGame instance = null;
        private static readonly object threadLock = new object(); // lock token
        public GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        public MonoGameRenderer renderer;

        public double Elapsed;

        private MonopolyGame()
        {
            graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "C:/xampp/htdocs/monopoly/Monopoly2019/Content";
            Content.RootDirectory = "E:/AA KTU failai/4 metai/7 semestras/Objektinis programų projektavimas/Monopoly2019/Monopoly2019/Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 700;
        }
        public static MonopolyGame getInstance()
        {
            lock(threadLock)
            {
                if (instance == null)
                {
                    instance = new MonopolyGame();
                }
            }
            return instance;
        }
        protected override void Initialize()
        {
            renderer = new MonoGameRenderer();
            StateMachine.Initialize();
            StateMachine.CurrentState = StateMachine.States["InitialState"];
            StateMachine.CurrentState.Execute();
            StateMachine.ChangeState();

            base.Initialize();

        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Elapsed = (double)gameTime.ElapsedGameTime.TotalSeconds;
            StateMachine.CurrentState.Execute();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatch.Begin();
            StateMachine.CurrentState.Draw(renderer);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
