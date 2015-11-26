using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration_2_AS4
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
            float screenX = (scaleX * position.X) - (textureWidth/2) * scale;
            float screenY = (scaleY * position.Y) - (textureHeight/2) * scale;

            return new Vector2(screenX, screenY);
        }

        public float getScale(float size, float width)
        {
            
                scale = scaleX * size / width;
            return scale;
        }
    }
}
