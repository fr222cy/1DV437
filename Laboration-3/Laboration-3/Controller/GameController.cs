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
        MouseAim mouseAim;
        
        List<ExplosionView> explosions = new List<ExplosionView>();
        BallView ballView;
        
        List<BallSimulation> ballSimulations = new List<BallSimulation>();

        Texture2D explosionTexture;
        Texture2D splitter;
        Texture2D smoke;
        Texture2D gameArea;
        Texture2D ball;
        Texture2D aim;
        SoundEffect blast;


        private bool spawnBalls = true;
        private int ballCounter = 0;
        private const int MAX_BALLS = 10;

        public GameController()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;
        }

     
        protected override void Initialize()
        {       
            base.Initialize();
        }

      
        protected override void LoadContent()
        {
           
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ball = Content.Load<Texture2D>("ball.png");
            smoke = Content.Load<Texture2D>("smoke.png");
            splitter = Content.Load<Texture2D>("red.png");
            explosionTexture = Content.Load<Texture2D>("explosion.png");           
            aim = Content.Load<Texture2D>("aim.png");
            blast = Content.Load<SoundEffect>("blastSound");
            gameArea = new Texture2D(GraphicsDevice, 1, 1);
            gameArea.SetData(new[] { Color.Black });


            ballView = new BallView(GraphicsDevice.Viewport);
            mouseAim = new MouseAim(GraphicsDevice.Viewport);
            

        }

        
        protected override void UnloadContent()
        {
         
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            //Mouse Click Tutorial->http://stackoverflow.com/questions/9712932/2d-xna-game-mouse-clicking
            
            lastMouseState = currentMouseState;

            currentMouseState = Mouse.GetState();
            var mousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);

            if (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed )
            {
                explosions.Add(new ExplosionView(GraphicsDevice.Viewport, mousePosition, blast));
                foreach(BallSimulation ballSimulation in ballSimulations)
                {
                    ballSimulation.isHit(mouseAim.shootPosition());
                }
                
            }

            //MouseAim
            mouseAim.update(mousePosition);
            
            //Update the explosionList.
            foreach(ExplosionView explosion in explosions)
            {
                explosion.update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            //Update the ballList.
            foreach(BallSimulation ballSimulation in ballSimulations)
            {
                ballSimulation.ballMovement((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            //Instantiate 10 balls.
            if(spawnBalls)
            {
                ballSimulations.Add(new BallSimulation(ballCounter));
                ballCounter++;

                if(ballCounter >= MAX_BALLS)
                {
                    spawnBalls = false;
                }

            } 
              
            base.Update(gameTime);
        }

     
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            //Draws the Game area.
            ballView.drawGameArea(gameArea, spriteBatch);

            //draws all ballsimulation (in this case 10).
            foreach(BallSimulation ballSimulation in ballSimulations)
            {
                ballView.Draw(spriteBatch, ball, ballSimulation);
            }
            
            //Draws all explosions in the list.
            foreach(ExplosionView explosion in explosions)
            {
                explosion.draw(splitter, smoke, explosionTexture, spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            foreach(BallSimulation ballsimulation in ballSimulations)
            {
                mouseAim.draw(aim, spriteBatch , ballsimulation);
            }
            
            

            base.Draw(gameTime);
        }
    }
}
