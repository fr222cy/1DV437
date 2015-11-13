using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration_1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ApplicationController : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera camera;
        

        Texture2D player;
        Texture2D whiteSquare;
        Texture2D blackSquare;

        public ApplicationController()
        {
            camera = new Camera();
            graphics = new GraphicsDeviceManager(this);
           
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 640;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera.scaleChess(graphics);   
            blackSquare = Content.Load<Texture2D>("black.png");
            whiteSquare = Content.Load<Texture2D>("white.png");
            player = Content.Load<Texture2D>("player.png");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

      

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        
            spriteBatch.Begin();
             
            int temp = 0;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {                                       
                        if (temp % 2 == 0)
                        {
                            spriteBatch.Draw(whiteSquare, camera.getVisualCoord(x, y), null, Color.White, 0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
                        }
                        else
                        {
                            spriteBatch.Draw(blackSquare, camera.getVisualCoord(x, y), null, Color.White, 0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
                        }
                        
                        temp++;
                }
                temp++;               
            }
            spriteBatch.Draw(player, camera.getRotated(2, 6), null, Color.White, 0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
