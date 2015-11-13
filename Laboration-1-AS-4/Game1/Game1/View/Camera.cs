using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Camera
    {

        private float scaleX;
        private float scaleY;
        private float border = 30;
        public float scale;

        public Camera(Viewport port)
        {
        
            scaleX = port.Width - (border * 2);
            scaleY = port.Height - (border * 2);

            if(scaleX < scaleY)
            {
                scale = scaleX;
            }
            else
            {
                scale = scaleY;
            }

        }

        public Vector2 modelToViewCoords(Vector2 position)
        {
            int screenX = (int)(scale * position.X + border);
            int screenY = (int)(scale * position.Y + border);
             
            return new Vector2(screenX, screenY);
        }

     

        public float getBorder()
        {
            return border;
        }

        public float getScale(float radius, int bounds)
        {
            return (scale/bounds) * (radius *2.0f) ;
        }
      
       
    }
}
