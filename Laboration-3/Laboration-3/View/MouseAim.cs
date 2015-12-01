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
    class MouseAim
    {
        Camera camera;
        Vector2 position;
       
        public MouseAim(Viewport port)
        {
            camera = new Camera(port);
        }

        public void update(Vector2 position)
        {
            this.position = camera.getClickModelCoords(position) ;
        }

        public void draw(Texture2D texture, SpriteBatch spriteBatch, BallSimulation ballSimulation)
        {
            spriteBatch.Begin();

            float scale = camera.getScale(ballSimulation.getHitRadius(),texture.Width * 1.15f);

            spriteBatch.Draw(texture, camera.getViewCoords(this.position, texture.Width, texture.Height), texture.Bounds, Color.White, 0f,Vector2.Zero, scale, SpriteEffects.None, 0);

            spriteBatch.End();
        }

        public Vector2 shootPosition()
        {       
            return this.position;
        }

        
        

        

    }
}
