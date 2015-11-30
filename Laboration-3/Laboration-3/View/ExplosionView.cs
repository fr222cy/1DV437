using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Laboration_3.View
{
    class ExplosionView
    {
        
        Camera camera;
        Splitter[] splitterParticles;
        List<Smoke> smokes = new List<Smoke>();
        Explosion explosion;

        private float size;
        private const int MAX_SPLITTER_PARTICLES = 50;
        private const int MAX_SMOKE_PARTICLES = 10;
        private const int NUM_OF_FRAMES = 81;
        private Vector2 startPosition;
        private float spawnTime;
        private float time;
        private bool playAnimation = true;
        private Random rand = new Random();
        private int frameCounter = 0;
       

        public ExplosionView(Viewport port, Vector2 startPosition, SoundEffect blast)
        {
            this.size = 0.1f;
            this.spawnTime = 0.1f;
            blast.Play();
            camera = new Camera(port);
            this.startPosition = camera.getClickModelCoords(startPosition);


            splitterParticles = new Splitter[MAX_SPLITTER_PARTICLES];

            for (int i = 0; i < MAX_SPLITTER_PARTICLES; i++)
            {
                splitterParticles[i] = new Splitter(i, camera, size, this.startPosition);
                splitterParticles[i].spawn();
            }

            explosion = new Explosion(camera, size, this.startPosition, NUM_OF_FRAMES);
            
        }

        public void addSmoke()
        {
                if(smokes.Count < MAX_SMOKE_PARTICLES)
                {
                    smokes.Add(new Smoke(rand, camera, size, startPosition));
                    smokes.ElementAt(smokes.Count - 1).spawn();
                }            
        }

        public void update(float elapsedTime)
        {
            time += elapsedTime;

            if(time > spawnTime)
            {
                addSmoke();
                time = 0;
            }

            foreach(Splitter splitterParticle in splitterParticles)
            {
                splitterParticle.update(elapsedTime);
            }

            foreach(Smoke smokeParticle in smokes)
            {
                smokeParticle.update(elapsedTime);
            }
           
        }

        public void draw(Texture2D splitter, Texture2D smoke, Texture2D explosionTexture, SpriteBatch spriteBatch, float elapsedTime)
        {
            
           
            foreach(Splitter splitterParticle in splitterParticles)
            {
                splitterParticle.draw(splitter, spriteBatch);
            }

            foreach(Smoke smokeParticle in smokes)
            {
                smokeParticle.draw(smoke, spriteBatch);
            }
            
                
            
                if(playAnimation)
                {
                    frameCounter++;
                    explosion.draw(explosionTexture, spriteBatch, elapsedTime);

                    if(frameCounter >= NUM_OF_FRAMES)
                    {
                        playAnimation = false;
                    }
                }
             
            
            
        }
    }
}
