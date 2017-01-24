using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Player2
    {
        private static Player2 p2 = null;
        public int score;
        public int numLives;

        public static Player2 createInstance()
        {
            if (p2 == null)
            {
                p2 = new Player2();
                p2.score = 0;
                p2.numLives = 3;
            }

            return p2;
        }

        public static Player2 getInstance()
        {
            return p2;
        }

        public static void addScore(int x)
        {
            Player2 p2 = Player2.getInstance();
            p2.score += x;
        }

        public static int getScore()
        {
            Player2 p2 = Player2.getInstance();
            return p2.score;
        }

        public static void deductLife()
        {
            Player2 p2 = Player2.getInstance();
            p2.numLives--;
        }

        public static int getLives()
        {
            Player2 p2 = Player2.getInstance();
            return p2.numLives;
        }
    }
}
