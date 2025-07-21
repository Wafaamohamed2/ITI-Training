using Raylib_cs;

namespace ITI_Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Raylib.InitWindow(800, 600, "ITI Day 4 - Shapes");

            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                // Create a rectangle
                Rectang rect = new Rectang(100, 100, 300, 200, Color.Gray);
                

                // Create  a circle
                Circle circle = new Circle(300, 100, 40, Color.DarkPurple);
                Circle circle2 = new Circle(100, 100, 40, Color.DarkPurple);

                // Create  a line
                Line line = new Line(100, 200, 100, 300, Color.LightGray);
                Line line2 = new Line(300, 200, 300, 300, Color.LightGray);

                // Draw the shapes
                Shap[] shapes = { rect, circle, line , circle2 , line2 };
                foreach (var shape in shapes)
                {
                    shape.Draw();
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
