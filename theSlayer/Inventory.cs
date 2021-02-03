using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theSlayer
{
    class Inventory
    {
        private bool oil = false;
        private bool flint = false;
        private bool stick = false;
        private bool torch = true;
        private bool exitKey = false;


        public void collectOil()
        { oil = true; }
        public void collectFlint()
        { flint = true; }
        public void collectStick()
        { stick = true; }
        public void craftTorch()
        { torch = true; }

        public void openExit()
        { exitKey = true; }


        public bool hasOil()
        { return oil; }
        public bool hasFlint()
        { return flint; }
        public bool hasStick()
        { return stick; }
        public bool hasTorch()
        { return torch; }

        public bool canLeave()
        { return exitKey; }

        public void reset()
        {
            this.oil = false;
            this.flint = false;
            this.stick = false;
            this.torch = false;
            this.exitKey = false;
        }
    }
}
