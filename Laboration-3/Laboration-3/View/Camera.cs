using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration_3.View
{
    class Camera
    {

        public float scaleX;
        public float scaleY;
        private float scale;
        public float border = 10;

        public Camera(Viewport port)
        {
            scaleX = port.Width - (border * 2);
            scaleY = port.Height - (border * 2);

            if(scaleX < scaleY)
            {
                scaleY = scaleX;
            }
            else
            {
                scaleX = scaleY;
            }

        }

        public Vector2 getViewCoords(Vector2 position, float textureWidth, float textureHeight )
        {
            float screenX =  ((scaleX * position.X) - (textureWidth / 2) * scale) + border  ;
            float screenY =  ((scaleY * position.Y) - (textureHeight / 2) * scale) + border;

            return new Vector2(screenX, screenY);
        }

        public Vector2 getClickModelCoords(Vector2 position)
        {
           
            float logicalX = (position.X / scaleX) - border /scaleX ;
            float logicalY = (position.Y / scaleY) - border /scaleY ;

           
            
            return new Vector2(logicalX, logicalY);
        }

        public float getScale(float size, float width)
        {
            scale = scaleX * size / width;

            return scale;
        }

        public float getBorder()
        {
            return border;
        }
    }
}
