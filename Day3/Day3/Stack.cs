using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Stack<T> 
    {

        public T[] values;
        public int Size { get; }
        public int Top;

        public Stack(int size)
        {
            Size = size;
            values = new T[size];
            Top = -1; 
        }

        public void Push(T value)
        {
            if (Top >= Size - 1)
            {
                Console.WriteLine("!!!Stack is Full");
                return;

            }
            values[++Top] = value;
            Console.WriteLine($"Pushed: {value}");
        }

        public T? Pop()
        {
            if (Top < 0)
            {
                Console.WriteLine("!!!Stack is empty");
                return default(T);
            }
            T value = values[Top--];
            Console.WriteLine($"Popped: {value}");
            return value;
        }

       
    }
}
