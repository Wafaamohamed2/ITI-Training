using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
namespace ITI_Day4
{
    internal class Line : Shap
    {

        Point Start;
        Point End;
        public Line()
        {
            Start = new Point(0, 0);    
            End = new Point(0, 0);
            Color = Raylib_cs.Color.Black;
        }


        public Line(Point start, Point end, Raylib_cs.Color color)
        {
            Start = start;
            End = end;
            Color = color;
        }

        public Line(int startX, int startY, int endX, int endY, Raylib_cs.Color color)
        {
            Start = new Point(startX, startY);
            End = new Point(endX, endY);
            Color = color;
        }
        public override void Draw()
        {
           Raylib.DrawLine(Start.gitX, Start.gitY, End.gitX, End.gitY, Color); // Draw the line using Raylib's DrawLine method   
        }
    }
}
