using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
namespace Game1.Model
{
    class BallSimulation
    {
        Ball ball;
        bool xDirection;
        bool yDirection;
        public BallSimulation()
        {
            xDirection = true;
            yDirection = true;
            ball = new Ball();
        }

        public void ballMovement(float time)
        {
            float x = ball.getPostion().X;
            float y = ball.getPostion().Y;

            Console.WriteLine("X = "+x+ " Y = "+y);
            
            ball.setPosition(time);

            if(x + ball.getRadius() > 1 && xDirection)
            {
                xDirection = false;
                ball.setXDirection(xDirection);
               
            }
            else if (x - ball.getRadius() <= 0 && !xDirection)
            {
                xDirection = true;
                ball.setXDirection(xDirection);
            }

            if (y + ball.getRadius() > 1 && yDirection)
            {
                yDirection = false;
                ball.setYDirection(yDirection);

            }
            else if (y - ball.getRadius() <= 0 && !yDirection)
            {
                yDirection = true;
                ball.setYDirection(yDirection);
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
