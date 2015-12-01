using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration_3.Model
{
    class Ball
    {
        
        Vector2 position;
        float radius;
        Vector2 speed;
        
        public Ball(Random rand)
        {
            position = new Vector2((float)rand.NextDouble(), (float)rand.NextDouble());
            radius = 0.04f;
            speed = new Vector2((float)rand.NextDouble(), (float)rand.NextDouble());
            
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

        public void setPosition1(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }

        public void stopBall()
        {
            speed = new Vector2(0, 0);
        }

        public float getRadius()
        {
            return radius;
        }

        public void setXDirection()
        {      
           speed.X = -(speed.X);  
        }
        public void setYDirection( )
        {
            speed.Y = -(speed.Y);
        }


    


    }
}
