using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration_2_AS4.Visuals
{
    class Explosion
    {

        private float time;
        private float maxTime = 2f;

        private int frameX;
        private int frameY;

        private int numFramesX = 9;
        private int numFramesY = 9;
        private int numOfFrames;
        private int frame_width;
        private int frame_height;

        private Camera camera;
        private Vector2 position;
        private float size;


        public Explosion(Camera camera, float size, Vector2 position, int numOfFrames )
        {
            this.position = position;
            this.size = size * 3;
            this.camera = camera;
            this.numOfFrames = numOfFrames;
        }

   
        public void draw(Texture2D spriteSheet, SpriteBatch spriteBatch, float elapsedTime)
        {

            time += elapsedTime;

            if (time >= maxTime)
            {
                time = 0;
            }

            float percentAnimated = time / maxTime;
            int frame = (int)(percentAnimated * numOfFrames);

            frameX = frame % numFramesX;
            frameY = frame / numFramesX;

            frame_width = spriteSheet.Width / numFramesX;
            frame_height = spriteSheet.Height / numFramesY;

            

            Rectangle texels = new Rectangle(frameX * frame_width, frameY * frame_height, frame_width, frame_height);

            float scale = camera.getScale(size, frame_width);

            spriteBatch.Begin();
           
            spriteBatch.Draw(spriteSheet, camera.getViewCoords(this.position, frame_width, frame_height), texels, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);

            spriteBatch.End();
        }
    }
}
