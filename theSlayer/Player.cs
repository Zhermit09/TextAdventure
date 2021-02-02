using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theSlayer
{
    class Player
    {
        private int currentPossionX = 3;
        private int currentPossionY = 6;

        public int x()
        { return currentPossionX; }

        public int y()
        { return currentPossionY; }

        public void setX(int x)
        { this.currentPossionX = x; }

        public void setY(int y)
        { this.currentPossionY = y; }

        public void reset()
        {
        this.currentPossionX = 3;
        this.currentPossionY = 6;
    }

        public int move(int cord, int move, int map, string symbol)
        {
            cord += move;
            if (cord > map || cord < 0 || symbol == "@")
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
