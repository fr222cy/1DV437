using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Laboration_1
{
    class Camera
    {
        public int sizeOfTile = 64;
        public int sizeOfBorder = 64;
        public float scale;
      

        public Vector2 getVisualCoord(int x, int y)
        {
            //VISUELL KOORDINAT 
            /*
             * 0,0 = 64, 64
             * 7,0 = 512, 64
             * 1,7 = 128, 512
             * 7,7 = 512, 512
            */


            int visualX = sizeOfBorder + x * sizeOfTile;
            int visualY = sizeOfBorder + y * sizeOfTile;

            return new Vector2(visualX, visualY);
        }
        
        public Vector2 getRotated(int x,int y)
        {
            
            //VISUELL KOORDINAT (Roterat)
            /*
             * 0,0 = 512, 512
             * 6,0 = 128, 512
             * 2,7 = 384, 64
             * 7,7 = 64, 64
            */
            int visualX = (sizeOfTile*8 + sizeOfBorder- sizeOfTile) -(x * sizeOfTile);
            int visualY = (sizeOfTile*8 + sizeOfBorder- sizeOfTile) -(y * sizeOfTile);

            return new Vector2(visualX, visualY);


        }

        public void scaleChess(GraphicsDeviceManager graphics)
        {
            float scaleX = (float)graphics.GraphicsDevice.Viewport.Width / (sizeOfTile * 8 + sizeOfBorder * 2);
            float scaleY = (float)graphics.GraphicsDevice.Viewport.Height / (sizeOfTile * 8 + sizeOfBorder * 2);

            if(scaleX < scaleY)
            {
                scale = scaleX;
            }
            else
            {
                scale = scaleY;
            }

            sizeOfBorder = Convert.ToInt32(Math.Round(scale * sizeOfBorder));
            sizeOfTile = Convert.ToInt32(Math.Round(scale * sizeOfTile));
            
        }
    }
}
