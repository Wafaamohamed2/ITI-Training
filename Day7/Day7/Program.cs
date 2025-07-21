namespace Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
             int[] arr = null;

            // to avoid code duplication, we will use a delegate to pass the comparison logic
            Action resetAndPrint = () =>
            {
                Console.WriteLine("-----------------------------------\n");
                arr = new int[] { 64, 34, 25, 12, 22, 11, 90 };
                Console.WriteLine("Original array:");
                PrintArray(arr);
            };

            resetAndPrint();

            // Ascending order .. use annonymous method as  delegate
            BubbleSort(arr, (x, y) => x > y);
            Console.WriteLine("Sorted array in ascending order:");
            PrintArray(arr);

           
            
            resetAndPrint();
            // Descending order .. use annonymous method as  delegate
            BubbleSort(arr, (x,y) => x < y);
            Console.WriteLine("Sorted array in descending order:");
            PrintArray(arr);
        }


        public delegate bool Compare(int z , int b);

        static void BubbleSort(int[] arr, Compare compare)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                // Print the current pass number for tracing
                Console.WriteLine($"Pass {i + 1}:");

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (compare(arr[j], arr[j + 1]))
                    {
                       
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                    Console.Write("Step: ");
                    PrintArray(arr);
                }
                Console.WriteLine();
            }
        }

        static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
