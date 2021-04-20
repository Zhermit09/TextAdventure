using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public int move(int cord, int move,  string symbol)
        {
            //Ändrar koordinater av spelaren 
            cord += move;
            //Om det är en vägg så tas tillbaka ändringen
            if (symbol == "@")
            {
                cord -= move;
                Console.WriteLine(
                    "Thee tries thine hardest to push back the wall yet it will not budge... no matter what..." +
                    "\n\nPress 'Enter' to continue");
                Console.ReadLine();


            }
            else
            {
                //Notis att koordinater var ändrade
                Console.SetCursorPosition((Console.BufferWidth - 8) / 2, 13);
                Console.WriteLine("You moved");
                Thread.Sleep(800);
            }
            return cord;
        }
    }

}
