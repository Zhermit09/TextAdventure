using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theSlayer
{
    class Map
    {
        private string[,] mapLayout = new string[,]
        {
            {"#","@","@","@","@","@","@","@"},
            {"-","@","@","¤","@","@","@","#"},
            {"-","-","-","-","-","-","-","-"},
            {"@","-","#","§","-","#","@","-"},
            {"-","-","-","-","-","-","-","-"},
            {"-","@","@","-","@","@","#","-"},
            {"-","@","@","-","@","@","-","-"},
            {"-","&","@","@","@","@","/","@"}

        };

        private string top =    " _____ ";
        private string wall =   "|     |";
        private string player = "| YOU |";
        private string bottom = "|_____|";


        //can combine
        public int mapX = 8;
        public int mapY = 8;

        public int getMapY()
        {
            return mapY;
        }
        public int getMapX()
        {
            return mapX;
        }
        public string getSymbol(int y, int x)
        {
            try
            {
                return mapLayout[y, x];
            }
            catch
            {
                //Om utanför array, räkna det som en vägg
                return "@";
            }
        }

        public void cheatMap(int x, int y, int px, int py)
        {
            //Sätter markören på ett lämligt ställe beroende på vilket rum det är
            //Varje rum består av 4 rader
            Console.SetCursorPosition(x * top.Length, y * 4);
            Console.Write(top);
            Console.SetCursorPosition(x * top.Length, (y * 4) + 1);
            Console.Write(wall);
            Console.SetCursorPosition(x * top.Length, (y * 4) + 2);
            //Kollar om spellaren är i rummet, om ja då esätts raden med en speciel rad
            if (x == px && y == py)
            {
                Console.Write(player);
            }
            else
            {
                Console.Write(wall);
            }
            Console.SetCursorPosition(x * top.Length, (y * 4) + 3);
            Console.Write(bottom);
        }

    }
}
