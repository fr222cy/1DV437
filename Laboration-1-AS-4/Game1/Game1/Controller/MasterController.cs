using Game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    
    

    public class MasterController : Game
    {
        BallView bv;
        BallSimulation bs;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ball;
        Texture2D gameArea;
        public MasterController()
        {           
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
     
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            
            base.Initialize();
        }

        //http://stackoverflow.com/questions/5751732/draw-rectangle-in-xna-using-spritebatch
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ball = Content.Load<Texture2D>("ball");
            gameArea = new Texture2D(GraphicsDevice, 1, 1);
            gameArea.SetData(new[] { Color.Yellow });

            
            bv = new BallView(GraphicsDevice.Viewport);
            bs = new BallSimulation();
           
            // TODO: use this.Content to load your game content here
        }

     
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            bs.ballMovement((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }


    
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            bv.drawGameArea(gameArea, spriteBatch);
            bv.Draw(spriteBatch, graphics, ball, bs);
            base.Draw(gameTime);
        }

    }
}
