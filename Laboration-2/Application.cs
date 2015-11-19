
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration2_AS1
{

    public class Application : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D particle;
        SplitterSystem splitterSystem;
        private bool SplitterIsStarted = false;
        public Application()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 500;
        }

     
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

     
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            particle = Content.Load<Texture2D>("spark.png");

          
            splitterSystem = new SplitterSystem();
        
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
                

            // TODO: Add your update logic here
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                
                splitterSystem.start(GraphicsDevice.Viewport);
                SplitterIsStarted = true;
            }
            
            if(SplitterIsStarted)
            {
                splitterSystem.particleMovement((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if(SplitterIsStarted)
            {
                splitterSystem.draw(particle, spriteBatch);
            }
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
