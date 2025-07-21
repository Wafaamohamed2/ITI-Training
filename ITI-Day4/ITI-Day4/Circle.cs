using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Day4
{
    class Circle : Shap
    {

        Point Center;
        int Radius;

        public Circle()
        {
            Center = new Point(0, 0);
            Radius = 0;
            Color = Raylib_cs.Color.Black;
        }

       
        
        public Circle(int centerX, int centerY, int radius, Raylib_cs.Color color)
        {
            Center = new Point(centerX, centerY);
            Radius = radius;
            Color = color;
        }

        public Circle(Point center, int radius)
        {
            Center = center;
            Radius = radius;
            
        }
        public override void Draw()
        {
            Raylib.DrawCircle(Center.gitX, Center.gitY, Radius, Color); 
        }
    }
}
