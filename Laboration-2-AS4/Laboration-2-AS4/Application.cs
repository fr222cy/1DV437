using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration_2_AS4
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Application : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ExplosionView expolsionView;
        Texture2D splitter;
        Texture2D smoke;
        Texture2D animation;

        bool isStarted = false;

        public Application()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;
        }

  
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.


            smoke = Content.Load<Texture2D>("smoke.png");
            splitter = Content.Load<Texture2D>("red.png");
            animation = Content.Load<Texture2D>("explosion.png");

            spriteBatch = new SpriteBatch(GraphicsDevice);
            expolsionView = new ExplosionView(GraphicsDevice.Viewport);
            // TODO: use this.Content to load your game content here
        }

     
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.R) || isStarted)
            {
                
                expolsionView.update((float)gameTime.ElapsedGameTime.TotalSeconds);
                isStarted = true;
            }

          

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            if(isStarted)
            {
                expolsionView.draw(splitter, smoke, animation, spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
                
            }
           
            base.Draw(gameTime);
        }
    }
}
