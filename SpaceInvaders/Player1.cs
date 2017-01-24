using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Player1
    {
        private static Player1 p1 = null;
        public int score;
        public int numLives;

        public static Player1 createInstance()
        {
            if (p1 == null)
            {
                p1 = new Player1();
                p1.score = 0;
                p1.numLives = 3;
            }

            return p1;
        }

        public static Player1 getInstance()
        {
            return p1;
        }

        public static void addScore(int x)
        {
            Player1 p1 = Player1.getInstance();
            p1.score += x;
        }

        public static int getScore()
        {
            Player1 p1 = Player1.getInstance();
            return p1.score;
        }

        public static void deductLife()
        {
            Player1 p1 = Player1.getInstance();
            p1.numLives--;
        }

        public static int getLives()
        {
            Player1 p1 = Player1.getInstance();
            return p1.numLives;
        }
    }
}
