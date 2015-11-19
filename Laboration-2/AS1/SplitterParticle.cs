using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration2_AS1
{
    class SplitterParticle
    {
   
        //private float size = 0.01f;
        private int seed;        
        private float maxSpeed;
        private float size;
        private Vector2 position;
        private Vector2 newPosition;
        private Vector2 velocity;
        private Vector2 acceleration;
        private Vector2 newVelocity;

        Camera camera;

        public SplitterParticle(int seed, Viewport port)
        {
            this.seed = seed;
            camera = new Camera(port);
            maxSpeed = 0.3f;
            size = 0.0002f;

            this.position = new Vector2(0.5f, 0.5f);
            acceleration = new Vector2(0, 1f);

        }

        public void spawnParticle()
        {
            Random rand = new Random(seed);

            //CODE FROM TIPS
            velocity = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            //normalize to get it spherical vector with length 1.0
            velocity.Normalize();
            //add random length between 0 to maxSpeed
            velocity = velocity * ((float)rand.NextDouble() * maxSpeed);

            
         }
         
       

         public void setPosition(float time)
         {
             newVelocity.X = time * acceleration.X + velocity.X;
             newVelocity.Y = time * acceleration.Y + velocity.Y;

             newPosition.X = time * newVelocity.X + this.position.X;
             newPosition.Y = time * newVelocity.Y + this.position.Y;

             this.position = newPosition;
             velocity = newVelocity;
         }
         

         public void draw(Texture2D particle, SpriteBatch spriteBatch)
         {

             float scale = camera.getScale(size);

             spriteBatch.Begin();
            
             spriteBatch.Draw(particle, camera.modelToViewCoords(this.position), particle.Bounds, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);

             spriteBatch.End();
             
             
         }
         
    }
}
