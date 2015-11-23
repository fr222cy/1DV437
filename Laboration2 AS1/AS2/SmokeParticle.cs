using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration2.AS2
{
    class SmokeParticle
    {
        Camera camera;
        private float size;
        private float minSize = 0.001f;
        private float maxSize = 0.015f;
        public float timeLived;
        public  float maxTimeLife = 3;
        private float maxSpeed;
        private float lifePercent;
        private Random rand;
        public float rotation = 0.0f;
        private Vector2 startPosition;
     
        private Vector2 position;
        private Vector2 newPosition;
        private Vector2 velocity;
        private Vector2 acceleration;
        private Vector2 newVelocity;

        private float fade = 1;
        Color color;


        public SmokeParticle(Random rand, Viewport port)
        {
            camera = new Camera(port);
            this.rand = rand;
            startPosition = new Vector2(0.5f, 0.99f);
            acceleration = new Vector2(0, -0.3f);
            color = new Color(fade, fade, fade, fade);
            timeLived = 0;
            maxSpeed = 0.1f;
           
     
            this.position = startPosition;
            
        }

        public void spawn()
        {
           

            //CODE FROM TIPS
            velocity = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            //normalize to get it spherical vector with length 1.0
            velocity.Normalize();
            //add random length between 0 to maxSpeed
            velocity = velocity * ((float)rand.NextDouble() * maxSpeed);

        }
        
        public void update(float time)
        {

            newVelocity.X = time * acceleration.X + velocity.X;
            newVelocity.Y = time * acceleration.Y + velocity.Y;

            newPosition.X = time * newVelocity.X + this.position.X;
            newPosition.Y = time * newVelocity.Y + this.position.Y;

            this.position = newPosition;
            velocity = newVelocity;

            timeTransform(time);

        }


        public void timeTransform(float time)
        {
            timeLived += time;

            lifePercent = timeLived / maxTimeLife;

            size = minSize + lifePercent * maxSize;

            //rotation
            rotation += (rand.Next(0,10) / 5) * (0.5f ) * time/2 ;
            

            //fades the smoke depending on how long it is suppose to live. 
            fade = maxTimeLife - timeLived ;

            color = new Color(fade, fade, fade, fade);

            //if the smoke has existed more than the maxTime. Reset the position, size, time and give it a random velocity again. 
            if(timeLived > maxTimeLife)
            {
                timeLived = 0;
                this.position = startPosition;
                spawn();
                size = minSize;
            }
        }
        

        public void draw(Texture2D particle, SpriteBatch spriteBatch)
        {

            float scale = camera.getScale(size);

            spriteBatch.Begin();
            
           
            spriteBatch.Draw(particle, camera.modelToViewCoords(this.position), particle.Bounds, color, rotation, Vector2.Zero, scale, SpriteEffects.None, 0);
            spriteBatch.End();

        }

    }
}
