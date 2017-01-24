using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienGridObserver : CollisionObserver
    {
        public bool moveDown2; 
        public AlienGridObserver()
        {

        }

        public override void notify()
        {
            Debug.WriteLine("AlienGridObserver: {0}, {1}", this.colSub.gObj1, this.colSub.gObj2);
            this.moveDown2 = true;

            Grid grid = this.colSub.gObj1 as Grid;
            Debug.Assert(grid != null);

            GameObject wall = this.colSub.gObj2;
            Debug.Assert(wall != null);

            if (wall.name == GameObject.Name.wallRight)
            {
                grid.moveDown = true;
                grid.xDelta = -5.0f;
               // grid.yDelta = 25.0f;
               

               // grid.moveDown = false;
                
                grid.iteratorDelta *= -1.0f;
                SoundManager.playFile("fastinvader4.wav");
               // grid.yDelta = grid.yDelta - 25.0f;
              //  grid.iteratorDelta = -1.0f;
            }
            else if (wall.name == GameObject.Name.wallLeft)
            {
                grid.moveDown = true;
                grid.xDelta = 5.0f;
             //   grid.pS.locY = grid.pS.locY - grid.yDelta;
                grid.iteratorDelta *= -1.0f;
                SoundManager.playFile("fastinvader4.wav");
              //  grid.yDelta = 25.0f;
               // grid.yDelta -= 25.0f;
             //   grid.iteratorDelta *= -1.0f;
            }
           else if (wall.name == GameObject.Name.wallRoot)
            {
                grid.xDelta = 1.0f;
                
                
              //  grid.iteratorDelta = -2.0f;
            } 
            else
            {
                Debug.WriteLine("broke");
            }
        }
    }
}
