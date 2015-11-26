using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration2.AS3
{
    class Explosion
    {
       
        private float time;
        private float maxTime = 0.5f;

        private int frameX;
        private int frameY;
        
        private int numFramesY = 8;
        private int numFramesX = 4;
        private int numberOfFrames = 48;
        private int frame_width;
        private int frame_height;

        private Texture2D animation;
        private Camera camera;
        private Vector2 startPosition;
        private float size;
        public Explosion(Texture2D animation, Viewport port)
        {
            camera = new Camera(port);
            this.animation = animation;
            this.startPosition = new Vector2(0.3f, 0.7f);
            this.size = 0.0020f;
        }

     

        public void draw(SpriteBatch spriteBatch, float elapsedTime)
        {

            time += elapsedTime;

            if (time >= maxTime)
            {
                time = 0;
            }

            float percentAnimated = time / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);

            frameX = frame % numFramesX;
            frameY = frame / numFramesX;

            frame_width = animation.Width / numFramesX;
            frame_height = animation.Height / numFramesY;

            float scale = camera.getScale(size);

            Rectangle texels = new Rectangle(frameX * frame_width, frameY * frame_height, frame_width, frame_height);

            spriteBatch.Begin();
            
            spriteBatch.Draw(animation, camera.modelToViewCoords(startPosition), texels, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);

            spriteBatch.End();

            

        }
    }
}
