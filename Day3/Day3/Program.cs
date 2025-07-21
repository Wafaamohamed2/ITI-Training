namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(3);
            
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
       
            // should be Overflow
            stack.Push(4);

            Console.WriteLine("-------------------");
            stack.Pop();
            stack.Pop();
            stack.Pop();
 
            // should be Underflow
            stack.Pop();

            Console.WriteLine("-------------------");

            Stack<string> s2 = new Stack<string>(2);
            s2.Push("Hello");
            s2.Push("World");

            s2.Pop();
            s2.Pop();
        }
    }
}
