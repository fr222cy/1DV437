using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Laboration_3.Model;


namespace Laboration_3.View
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

        public void Draw(SpriteBatch spriteBatch, Texture2D ball, BallSimulation bs)
        {

            float scale = camera.getScale(bs.ballRadius(), ball.Width/2);

            spriteBatch.Begin();

            spriteBatch.Draw(ball, camera.getViewCoords(bs.position(), ball.Width, ball.Height), ball.Bounds, Color.White, 0, Vector2.Zero , scale, SpriteEffects.None, 0);

            spriteBatch.End();
        }


        public void drawGameArea(Texture2D gameArea, SpriteBatch spriteBatch)
        {

            int areaWidth = (int)camera.scaleX;
            int areaHeight = (int)camera.scaleY;
            
            int border = (int)camera.getBorder();

            spriteBatch.Begin();

            spriteBatch.Draw(gameArea, new Rectangle(border, border, areaWidth, areaHeight), Color.White);

            spriteBatch.End();

        }

    }

        

}
