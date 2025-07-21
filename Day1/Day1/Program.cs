namespace Day1
{
    internal class Program
    {
        static void Main(string[] args) {
            //{
            //    Console.WriteLine("Assignment 1\n");
            //    Console.Write("Enter Frist Number:");
            //    int x = int.Parse(Console.ReadLine());

            //    Console.Write("Enter Sec Number:");
            //    int y = int.Parse(Console.ReadLine());

            //    int sum = x + y;
            //    Console.WriteLine("Sum = " + sum);

            //    int avg = sum / 2;
            //    Console.WriteLine("Average = " + avg);




            //    Console.WriteLine("Assignment 2");

            //    Console.Write("Enter Frist Number:");
            //    int a = int.Parse(Console.ReadLine());

            //Console.Write("Enter Sec Number:");
            //    int b = int.Parse(Console.ReadLine());

            //Console.Write("Please select an option (1-3 or Exite): \n 1- for Summition \n 2- for get max num \n 3- for git min num \n");
            //    int OpNum = int.Parse(Console.ReadLine());

            //    switch (OpNum)
            //    {
            //        case 1:
            //            int sum = a + b;
            //Console.WriteLine($"Summition is: " + sum);
            //            break;
            //        case 2:
            //            int max = Math.Max(a, b);
            //Console.WriteLine("Max number is: " + max);
            //            break;
            //        case 3:
            //            int min = Math.Min(a, b);
            //Console.WriteLine("Min number is: "+ min);
            //            break;

            //        default:
            //            Console.WriteLine("Exite");
            //            break;
            //    }





            //Console.WriteLine("Assignment 3");
            //Console.Write("Enter Frist Number:");
            //int x = int.Parse(Console.ReadLine());

            //Console.Write("Enter Sec Number:");
            //int y = int.Parse(Console.ReadLine());

            //Console.Write("Please select an operation : (* or / or + or -) ");
            //string operation = Console.ReadLine();

            //int result = 0;
            //if (operation == "*")
            //{
            //    result = x * y;
            //    Console.WriteLine("Multiplication = " + result);

            //}
            //else if (operation == "/")
            //{
            //    result = x / y;
            //    Console.WriteLine("Division = " + result);
            //}
            //else if (operation == "+")
            //{
            //    result = x + y;
            //    Console.WriteLine("Addition = " + result);
            //}
            //else if (operation == "-")
            //{
            //    result = x - y;
            //    Console.WriteLine("Subtraction = " + result);
            //}
            //else
            //{
            //    Console.WriteLine("Invalid operation selected.");
            //    return;
            //}






            Console.WriteLine("Assignment 4");

            Console.Write("Enter an odd number: ");
            int n = int.Parse(Console.ReadLine());

            int maxNum = n * n;

            int row = 0;
            int col = n / 2;

            int consoleWidth = 120;
            int consoleHeight = 50;

            int colSpacing = consoleWidth / (n + 1);
            int rowSpacing = (consoleHeight - 2) / (n + 1);

            for (int num = 1; num <= maxNum; num++)
            {
                int x = colSpacing + (col * colSpacing);
                int y = rowSpacing + (row * rowSpacing);

                if (x >= consoleWidth - 4) x = consoleWidth - 5;
                if (y >= consoleHeight - 1) y = consoleHeight - 2;

                Console.SetCursorPosition(x, y);
                Console.Write($"{num,2}");

                if (num % n == 0)
                {
                    row = (row + 1) % n;
                }

                else
                {
                    row = (row - 1 + n) % n;
                    col = (col - 1 + n) % n;
                }

            }
            Console.SetCursorPosition(0, consoleHeight + n * 2 + 2);
        }
    }
}
