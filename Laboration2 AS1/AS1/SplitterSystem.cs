using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration2.AS1
{
    class SplitterSystem
    {
        
        SplitterParticle[] particles;
        private const int maxParticles = 100;
       

        public void start(Viewport port)
        {
            particles = new SplitterParticle[maxParticles];


            for (int i = 0; i < maxParticles; i++)
            {
                particles[i] = new SplitterParticle(i, port);
                particles[i].spawnParticle();
            }
        }

        public void update(float time)
        {
            for (int i = 0; i < maxParticles; i++)
            {
                particles[i].setPosition(time);
            }
        }

        public void draw(Texture2D particle, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < maxParticles; i++)
            {
                particles[i].draw(particle, spriteBatch);
            }
        }
    }
}
