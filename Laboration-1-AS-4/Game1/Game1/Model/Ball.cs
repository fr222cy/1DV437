using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.Model
{
    class Ball
    {

        Vector2 position;
        float radius;
        Vector2 speed;
        public Ball()
        {
            position = new Vector2(0.5f, 0.3f);
            radius = 0.05f;
            speed = new Vector2(0.5f, 0.3f);
        }

        public Vector2 getPostion()
        {
            return position;
        }

        public void setPosition(float time)
        {
            position.Y += speed.Y * time;
            position.X += speed.X * time;
        }

        public float getRadius()
        {
            return radius;
        }

        public void setXDirection(bool direction)
        {      

               if(!direction)
               {
                   speed.X = -(speed.X);
                 
               }
               else
               {
                   speed.X = -(speed.X);
              
               }
               
        }
        public void setYDirection(bool direction)
        {

            if (!direction)
            {
                speed.Y = -(speed.Y);

            }
            else
            {
                speed.Y = -(speed.Y);

            }

        }


    


    }
}
