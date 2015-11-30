using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration_3.View
{
    class Smoke
    {
       
        private Camera camera;
        private Color color;

        private Random rand;

        private float size;
        private float minSize;
        private float maxSize;
        private float maxLifeTime;
        private float maxSpeed;
        private float fade = 1;
        private float rotation;
        private float lifePercent;
        private float lifeTime;


        private Vector2 position;
        private Vector2 newPosition;
        private Vector2 velocity;
        private Vector2 acceleration;
        private Vector2 newVelocity;
        

        


        public Smoke(Random rand, Camera camera, float size, Vector2 position)
        {
            this.rand = rand;
            this.camera = camera;

          
            this.minSize = size * 0.5f;
            this.maxSize = size * 3f;

            this.position = position ;
            this.maxLifeTime = 3;
            this.maxSpeed = 0.1f;
            this.acceleration = new Vector2(0, -0.1f);
        }

        public void spawn()
        {
            velocity = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            //normalize to get it spherical vector with length 1.0
            velocity.Normalize();
            //add random length between 0 to maxSpeed
            velocity = velocity * ((float)rand.NextDouble() * maxSpeed);
        }

        

        public void update(float elapsedTime)
        {
            newVelocity.X = elapsedTime * acceleration.X + velocity.X;
            newVelocity.Y = elapsedTime * acceleration.Y + velocity.Y;

            newPosition.X = elapsedTime * newVelocity.X + this.position.X;
            newPosition.Y = elapsedTime * newVelocity.Y + this.position.Y;

            this.position = newPosition;
            velocity = newVelocity;

            timeTransform(elapsedTime);
        }

        public void timeTransform(float elapsedTime)
        {
            lifeTime += elapsedTime;

            lifePercent = lifeTime / maxLifeTime;

            size = minSize + lifePercent * maxSize;

            //rotation
            rotation += (rand.Next(0, 10) / 5) * (0.5f) * elapsedTime / 2;


            //fades the smoke depending on how long it is suppose to live. 
            fade = maxLifeTime - lifeTime;

            color = new Color(fade, fade, fade, fade);
            

        }


        public void draw(Texture2D texture, SpriteBatch spriteBatch)
        {

            float scale = camera.getScale(size, texture.Width);

            spriteBatch.Begin();
            
            spriteBatch.Draw(texture, camera.getViewCoords(this.position, texture.Width, texture.Height), texture.Bounds, color, rotation, Vector2.Zero, scale, SpriteEffects.None, 0);
            
            spriteBatch.End();

        }
    
    }
}
