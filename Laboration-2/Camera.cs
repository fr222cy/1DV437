using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration2_AS1
{
    class Camera
    {
        private float scaleX;
        private float scaleY;
        private float scale;

        public Camera(Viewport port)
        {
            scaleX = port.Width;
            scaleY = port.Height;

  
            if (scaleX < scaleY)
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
            int screenX = (int)(scale * position.X );
            int screenY = (int)(scale * position.Y );
          
            return new Vector2(screenX, screenY);
        }

        public float getScale(float size)
        {
            return scale * size;
        }
       
    }
}
