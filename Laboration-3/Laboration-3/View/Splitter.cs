using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration_3.View
{
    class Splitter
    {
        private Camera camera;

        private int seed;
        private float size;
        private float maxSpeed;

        private Vector2 position;
        private Vector2 newPosition;
        private Vector2 velocity;
        private Vector2 newVelocity;
        private Vector2 acceleration;



        private float time;
        private bool touched = false;

        public Splitter(int seed, Camera camera, float size, Vector2 position)
        {
            this.camera = camera;
            this.seed = seed;
            this.size = size * 0.1f;
            this.maxSpeed = 1f;
            this.position = position;
            this.acceleration = new Vector2(0, 0.5f);
        }

        public void spawn()
        {
            Random rand = new Random(seed);

            //CODE FROM TIPS
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


            if (this.position.X >= 0.99 || position.X < 0.01)
            {
                velocity = new Vector2(0, 0.5f);
            }

            if (this.position.Y > 0.99f || touched)
            {
                touched = true;
                time += elapsedTime;




                velocity = Vector2.Zero;
                acceleration = Vector2.Zero;

            }
        }

        public void draw(Texture2D texture, SpriteBatch spriteBatch)
        {

            float scale = camera.getScale(size, texture.Width);
            
            spriteBatch.Begin();
            
            spriteBatch.Draw(texture, camera.getViewCoords(this.position, texture.Width, texture.Height), texture.Bounds, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
          
            spriteBatch.End();

        }
    }
}
