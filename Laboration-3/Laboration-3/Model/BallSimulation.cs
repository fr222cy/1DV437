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
        private float hitRadius;
        private float x;
        private float y;
        public BallSimulation(int seed)
        {
            hitRadius = 0.1f;
            Random rand = new Random(seed);
            ball = new Ball(rand);
        }

        public void ballMovement(float time)
        {
            x = ball.getPostion().X;
            y = ball.getPostion().Y;

            ball.setPosition(time);
            checkCollision();
        }

        public void checkCollision()
        {
            if (x + ball.getRadius() > 1)
            {
                ball.setPosition1(1 - ball.getRadius(), y);
                ball.setXDirection();

            }
            else if (x - ball.getRadius() < 0)
            {
                ball.setPosition1(0 + ball.getRadius(), y);
                ball.setXDirection();
            }

            if (y + ball.getRadius() > 1)
            {
                ball.setPosition1(x, 1 - ball.getRadius());

                ball.setYDirection();
            }
            else if (y - ball.getRadius() < 0)
            {
                ball.setPosition1(x, 0 + ball.getRadius());
                ball.setYDirection();
            }
        }

        public void isHit(Vector2 position)
        {
            // Quite buggy solution..
            if (x >= position.X - hitRadius && x <= position.X + hitRadius &&
                y >= position.Y - hitRadius && x <= position.Y + hitRadius)
            {
                ball.stopBall();
            }
        }

        public float getHitRadius()
        {
            return hitRadius;
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
