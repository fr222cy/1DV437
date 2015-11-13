using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Model;


namespace Game1
{
    class BallView
    {

        Camera camera;
        Viewport m_port;
        public BallView(Viewport port)
        {
            m_port = port;
            camera = new Camera(port);
        }

        public void Draw(GameTime gametime, SpriteBatch spriteBatch, GraphicsDeviceManager graphics, Texture2D ball, BallSimulation bs)
        {
         
            float scale = camera.getScale(bs.ballRadius(), ball.Bounds.Width);

            spriteBatch.Begin();

                spriteBatch.Draw(ball, camera.modelToViewCoords(bs.position()), ball.Bounds, Color.White, 0, new Vector2(ball.Bounds.Width / 2, ball.Bounds.Height / 2), scale, SpriteEffects.None, 0);
             
            spriteBatch.End();
        }


        public void drawGameArea(Texture2D gameArea, SpriteBatch spriteBatch)
        {

            int xAxis = m_port.Width;
            int yAxis = m_port.Height;
            int gameAreaScaled = (int)camera.scale;
            int border = (int)camera.getBorder();

            spriteBatch.Begin();

                spriteBatch.Draw(gameArea, new Rectangle(border, border , gameAreaScaled , gameAreaScaled), Color.White);
             

            spriteBatch.End();

        }

    }

        

}
