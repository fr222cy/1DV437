using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration2.AS3
{
    class AnimationSystem
    {

     
        private Explosion explosion;
        private Viewport port;
       
        

        public void start(Texture2D animation,Viewport port)
        {
            this.port = port;
            explosion = new Explosion(animation, port);
           
        }

        public void draw(SpriteBatch spriteBatch, float elapsedTime)
        {
            if(explosion != null)
            {
                explosion.draw(spriteBatch, elapsedTime);
            }
            
        }

    }
}
