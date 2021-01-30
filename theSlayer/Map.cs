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
            {"#","¤","#",},
            {"&","§","/",},
            {"#","-","#",},
        };

        public string getSymbol(int y, int x)
        {
            return mapLayout[y,x];
        }

        public void drawMap()
        {
            Console.WriteLine("");
        }
    }
}
