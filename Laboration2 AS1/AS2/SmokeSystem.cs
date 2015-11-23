using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
namespace Laboration2.AS2
{
    class SmokeSystem
    {
        private List<SmokeParticle> particles = new List<SmokeParticle>();
        private const int maxParticles = 100;
        private Random rand = new Random();
        private Viewport port;
        private float spawnTime = 0.05f;
        private float time;
        public void start(Viewport port)
        {
            this.port = port;
                
        }

        public void addParticle()
        {
            if(particles.Count <= maxParticles)
            {
                particles.Add(new SmokeParticle(rand, port));
                particles.ElementAt(particles.Count - 1).spawn();
                Console.WriteLine(particles.ElementAt(0).rotation); 
            }
        }

       


        public void update(float elapsedTime)
        {
            time += elapsedTime;
             
            //Now adds 10 smoke particles a second. 
            if(time >= spawnTime )
            {
                addParticle();
                time = 0;
            }
     
            foreach(SmokeParticle particle in particles)
            {
                
                particle.update(elapsedTime);
                
                //Console.WriteLine(particle.timeLived);
            }
                
        }

        public void draw(Texture2D particleTexture, SpriteBatch spriteBatch)
        {
            foreach (SmokeParticle particle in particles)
            {              
                    particle.draw(particleTexture, spriteBatch);

            }

        }

      
    }
}
