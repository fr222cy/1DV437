using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Laboration_3.Model
{
    class BallSimulation
    {
        Ball ball;
     
        public BallSimulation()
        {
            ball = new Ball();
        }

        public void ballMovement(float time)
        {
            float x = ball.getPostion().X;
            float y = ball.getPostion().Y;

            Console.WriteLine(x +" "+ y);
            
            ball.setPosition(time);

            if(x + ball.getRadius() > 1)
            {
                ball.setPosition1(1 - ball.getRadius(), y);
                ball.setXDirection();
               
            }
            else if (x - ball.getRadius() < 0 )
            {
                ball.setPosition1(0 + ball.getRadius(), y);
                ball.setXDirection();
            }

            if (y + ball.getRadius() > 1 )
            {
                ball.setPosition1(x, 1 - ball.getRadius());
          
                ball.setYDirection();
            }
            else if (y - ball.getRadius() < 0 )
            {
                ball.setPosition1(x, 0 + ball.getRadius());
           
                ball.setYDirection();
            }
        }

        

        public float ballRadius()
        {
            return ball.getRadius();
        }

        public Vector2 position()
        {
            return ball.getPostion();
        }
    }
}
