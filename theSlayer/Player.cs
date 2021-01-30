using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theSlayer
{
    class Player
    {
        private int currentPossionX = 1;
        private int currentPossionY = 2;

        public int x()
        { return currentPossionX; }

        public int y()
        { return currentPossionY; }

        public void setX(int x)
        { this.currentPossionX = x; }

        public void setY(int y)
        { this.currentPossionY = y; }

        public int move(int cord, int move)
        {
            cord += move;

            if (cord > 2 || cord < 0)
            {
                cord -= move;
                Console.WriteLine(
                    "That is a wall" +
                    "\nPress 'Enter' to continue");
                Console.ReadLine();
            }
            return cord;
        }
    }

}
