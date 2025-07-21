using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Day4
{
    class Rectang : Shap
    {
        Point UL;
        Point LR;

        public Rectang()
        {
            UL = new Point(0, 0);
            LR = new Point(0, 0);
            Color = Raylib_cs.Color.Black;
        }

        public Rectang(int x1 , int y1 ,int x2, int y2, Raylib_cs.Color color)
        {
            UL = new Point(x1,y1);
            LR = new Point(x2, y2);
            Color = color;
        }

        public override void Draw()
        {
            int width = LR.gitX - UL.gitX;
            int height = LR.gitY - UL.gitY;
            Raylib.DrawRectangle(UL.gitX, UL.gitY, width, height, Color); 
        }
    }
}
