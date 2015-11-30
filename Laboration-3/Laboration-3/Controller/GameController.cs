using Laboration_3.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Laboration_3.Model;
namespace Laboration_3.Controller
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameController : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        

        MouseState lastMouseState;
        MouseState currentMouseState;

        
        List<ExplosionView> explosions = new List<ExplosionView>();
        BallView ballView;
        BallSimulation ballSimulation;

        Texture2D explosionTexture;
        Texture2D splitter;
        Texture2D smoke;
        Texture2D gameArea;
        Texture2D ball;
        SoundEffect blast;

       

        public GameController()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;
        }

     
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
         
            base.Initialize();
        }

      
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ball = Content.Load<Texture2D>("ball.png");
            smoke = Content.Load<Texture2D>("smoke.png");
            splitter = Content.Load<Texture2D>("red.png");
            explosionTexture = Content.Load<Texture2D>("explosion.png");
            blast = Content.Load<SoundEffect>("blastSound");

            ballView = new BallView(GraphicsDevice.Viewport);
            ballSimulation = new BallSimulation();
            gameArea = new Texture2D(GraphicsDevice, 1, 1);
            gameArea.SetData(new[] { Color.Black });

          
        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            //MOUSE
            //http://stackoverflow.com/questions/9712932/2d-xna-game-mouse-clicking

            lastMouseState = currentMouseState;

            currentMouseState = Mouse.GetState();

            if (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed )
            {
                var mousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);
            

                explosions.Add(new ExplosionView(GraphicsDevice.Viewport, mousePosition, blast));
                
            }

           
            foreach(ExplosionView explosion in explosions)
            {
                explosion.update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            ballSimulation.ballMovement((float)gameTime.ElapsedGameTime.TotalSeconds);
            
            // TODO: Add your update logic here           


            base.Update(gameTime);
        }

     
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            ballView.drawGameArea(gameArea, spriteBatch);
            ballView.Draw(spriteBatch, ball, ballSimulation);
            foreach(ExplosionView explosion in explosions)
            {
                explosion.draw(splitter, smoke, explosionTexture, spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            

            base.Draw(gameTime);
        }
    }
}
