using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Day4
{
    public class Point
    {
        private int x , y;
        public Point (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int gitX { get { return x; } }
        public int gitY { get { return y; } }

        public void setX(int x) { this.x = x; }

        public void setY(int y) { this.y = y; }


                


    }
}
