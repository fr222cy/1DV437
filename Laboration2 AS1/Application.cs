using Laboration2.AS1;
using Laboration2.AS2;
using Laboration2.AS3;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration2
{

    public class Application : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D AS1particle;
        Texture2D AS2particle;
        Texture2D AS3Animation;

        SplitterSystem splitterSystem;
        SmokeSystem smokeSystem;
        AnimationSystem animationSystem;

        private bool AS1isStarted = false;
        private bool AS2isStarted = false;
        private bool AS3isStarted = false;

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

            AS1particle = Content.Load<Texture2D>("spark.png");
            AS2particle = Content.Load<Texture2D>("particlesmoke.png");
            AS3Animation = Content.Load <Texture2D>("explosion.png");
            splitterSystem = new SplitterSystem();
            smokeSystem = new SmokeSystem();
            animationSystem = new AnimationSystem();
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
                AS1isStarted = true;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D2) && !AS2isStarted)
            {

                smokeSystem.start(GraphicsDevice.Viewport);
                AS2isStarted = true;
                
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D3) && !AS3isStarted)
            {
                animationSystem.start(AS3Animation, GraphicsDevice.Viewport);
                AS3isStarted = true;
            }


            
            if(AS1isStarted)
            {
                splitterSystem.update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if(AS2isStarted)
            {
                smokeSystem.update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

         
            

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if(AS1isStarted)
            {
                splitterSystem.draw(AS1particle, spriteBatch);
            }

            if (AS2isStarted)
            {
                smokeSystem.draw(AS2particle, spriteBatch);
            }

            if(AS3isStarted)
            {
                animationSystem.draw(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
