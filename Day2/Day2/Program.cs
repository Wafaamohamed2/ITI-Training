using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Xml.Linq;
using ClassLibrary1;
namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region
            //Console.Write("Enter How many numbers do you want: ");
            //int count = int.Parse(Console.ReadLine());

            //int[] nums = new int[count];
            //for (int i = 0; i < count; i++)
            //{
            //    Console.Write($"Enter number {i + 1}: ");
            //    nums[i] = int.Parse(Console.ReadLine());
            //}

            //int sum = nums.Sum();
            //double average = nums.Average();
            //int max = nums.Max();
            //int min = nums.Min();

            //Console.WriteLine("Sum     = " + sum);
            //Console.WriteLine("Average = " + average);
            //Console.WriteLine("Max     = " + max);
            //Console.WriteLine("Min     = " + min);


            #endregion

            #region
            //Console.Write("\nEnter an equation  or type 'exit' to quit: ");
            //    string equation = Console.ReadLine();

            //    if (equation == "exit"  )
            //    {

            //        Console.WriteLine("Exiting");


            //    }

            //    char[] operators = { '+', '-', '*', '/' };
            //    int operatorIndex = equation.IndexOfAny(operators);

            //    int left = int.Parse(equation.Substring(0, operatorIndex).Trim());
            //    int right = int.Parse(equation.Substring(operatorIndex + 1).Trim());
            //    char op = equation[operatorIndex];

            //    int result = 0;

            //    switch (op)
            //    {
            //        case '+':
            //            result = left + right;
            //            break;

            //        case '-':
            //            result = left - right; break;

            //        case '*':
            //            result = left * right; break;

            //        case '/':
            //            result = left / right; break;

            //        default:
            //            Console.WriteLine("Unknown operator.");
            //            break;
            //    }

            //    Console.WriteLine(equation + "= " + result);

            #endregion

            #region

            //int[,] stdDeg = new int[3, 4];

            //for (int i = 0; i < stdDeg.GetLength(0); i++)
            //{

            //    Console.WriteLine($"\nEnter marks for Student {i + 1}:");

            //    for (int j = 0; j < stdDeg.GetLength(1); j++)
            //    {


            //        Console.Write($"Subject {j + 1}: ");
            //        stdDeg[i, j] = int.Parse(Console.ReadLine());
            //    }
            //}

            //Console.WriteLine("-----------------");
            //for (int i = 0; i < stdDeg.GetLength(0); i++)
            //{
            //    int sum = 0;
            //    for (int j = 0; j < stdDeg.GetLength(1); j++)
            //    {
            //        sum += stdDeg[i, j];
            //    }

            //    Console.WriteLine($"Total Degrees for Student {i + 1}: {sum}");
            //}
            //Console.WriteLine("------------------");
            //for (int j = 0; j < stdDeg.GetLength(1); j++)
            //{
            //    int subjectSum = 0;
            //    for (int i = 0; i < stdDeg.GetLength(0); i++)
            //    {
            //        subjectSum += stdDeg[i, j];
            //    }

            //    double average = (double)subjectSum / stdDeg.GetLength(0);
            //    Console.WriteLine($"Average for Subject {j + 1}: {average:F2}");
            //}


            #endregion

            #region

            //Console.Write("Enter the number of class rooms: ");
            //int classCount = int.Parse(Console.ReadLine());

            //int[][] Degrees = new int[classCount][];

            //for (int i = 0; i < classCount; i++)
            //{
            //    Console.Write($"Enter the number of students in class {i + 1}: ");
            //    int studentCount = int.Parse(Console.ReadLine());

            //    Degrees[i] = new int[studentCount];

            //    for (int j = 0; j < studentCount; j++)
            //    {
            //        Console.Write($"Enter the degree for student {j + 1} in class {i + 1}: ");
            //        Degrees[i][j] = int.Parse(Console.ReadLine());
            //    }

            //}
            //Console.WriteLine("---------------------------");
            //for (int i = 0; i < classCount; i++)
            //{
            //    int sum = 0;
            //    foreach (int mark in Degrees[i])
            //    {
            //        sum += mark;

            //    }

            //    double average = (double)sum / classCount;

            //    Console.WriteLine($"Average mark for class {i + 1}:  {average:F2}");
            //}

            #endregion


            #region

            string[] menuItems = { "New", "Display", "Search", "Sort","Save to File", "Load from File", "Exit" };
            int X = Console.WindowWidth / 2;
            int Y = Console.WindowHeight / 4;
            int hight = 0;


            //int id = 0;
            //string name = "";
            //float Salary = 0.0f;

            // Employee employee =null;

            List<Employee> employeeList = new List<Employee>();


            bool Loop = true;

            do
            {

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == hight) { Console.BackgroundColor = ConsoleColor.DarkCyan; }
                    else
                    { Console.BackgroundColor = ConsoleColor.Black; }
                    Console.SetCursorPosition(X, Y * (i + 1));
                    Console.WriteLine(menuItems[i]);
                }

                ConsoleKeyInfo k = Console.ReadKey();

                switch (k.Key)
                {
                    case ConsoleKey.DownArrow:
                        hight++;
                        if (hight >= menuItems.Length)
                            hight = 0;
                        break;

                    case ConsoleKey.UpArrow:
                        hight--;
                        if (hight < 0)
                            hight = menuItems.Length - 1;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (hight)
                        {
                            case 0:
                                NewMethod();
                                break;

                            case 1: // display
                                DisplayMethod();
                                break;

                            case 2: // Search
                                SearchEmployee();
                                break;

                            case 3: // Sort
                                SortEmployee();
                                break;

                            case 4:
                                SaveToFile();
                                break;

                            case 5:
                                LoadFromFile();
                                break;


                            case 6: // Exit
                                ExitMethod();
                                Loop = false;
                                break;

                        }
                        break;
                }

            } while (Loop);



            //----------------------methods -----------------------------

            void NewMethod()
            {
                do
                {
                    try { 
                        Console.Write("Enter Employee ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Employee Name: ");
                        string name = Console.ReadLine(); 
                        
                        Console.Write("Enter Employee Salary: ");
                        float salary = float.Parse(Console.ReadLine());

                        int age;
         
                        while (true)
                        {
                            Console.Write("Enter Employee Age (18-60): ");
                            age = int.Parse(Console.ReadLine());
                            if (age >= 18 && age <= 60) break;
                            Console.WriteLine("Age must be between 18 and 60.");
                        }

                        employeeList.Add(new Employee(id, name, salary, age));
                   
                        Console.WriteLine("Employee data saved successfully!");

                        Console.Write("Want to Add another employee? (y/n): ");

                    }
                    catch (Exception e) {
                        Console.WriteLine($"Error: {e.Message}");

                    }


                }while (Console.ReadLine().ToLower() == "y");

            }


             void DisplayMethod()
             {
                Console.WriteLine("All Employees Data:");

                if (employeeList.Count == 0)
                {
                    Console.WriteLine("No employees to display.");
                    return;
                }

                foreach (var item in employeeList)
                {
                    item.DisplayData();
                    Console.WriteLine("--------------------");
                }

             }

            void SearchEmployee()
            {
                Console.Write("Search by (1) ID or (2) Name? ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter Employee ID: ");
                    int id = int.Parse(Console.ReadLine());

                    var emp = employeeList.Find(e => e.Id == id);
                    if (emp != null)
                        emp.DisplayData();
                    else
                        Console.WriteLine("Employee not found.");
                }

                else if (choice == "2")
                {
                    Console.Write("Enter Employee Name: ");
                    string name = Console.ReadLine();

                    var emp = employeeList.Find(e => e.Name.Equals(name));

                    if (emp != null)
                        emp.DisplayData();
                    else
                        Console.WriteLine("Employee not found.");
                }

                else
                {
                    Console.WriteLine("Invalid choice.");
                   
                }
            
            }



             void SortEmployee()
             {
                Console.WriteLine("Sort by:");
                Console.WriteLine("1. ID Ascending");
                Console.WriteLine("2. ID Descending");
                Console.WriteLine("3. Name");
                Console.WriteLine("4. Salary");
                Console.Write("Enter your choice: \n");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        employeeList.Sort(new SortByIdAsc());
                        break;

                    case "2":
                        employeeList.Sort(new SortByIdDesc());
                        break;

                    case "3":
                        employeeList.Sort(new SortByName());
                        break;

                    case "4":
                        employeeList.Sort(new SortBySalary());
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                } 
                DisplayMethod();
                Console.WriteLine("Sorted successfully.\n");
               
             }

            void SaveToFile()
            {
                try
                {
                    Console.Write("Enter file name to save ( data.json or data.txt) : ");

                    string fileName = Console.ReadLine();

                    string extension = Path.GetExtension(fileName).ToLower();

                    if (extension == ".json")
                    {
                        string json = JsonSerializer.Serialize(employeeList, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(fileName, json);
                    }
                    else if (extension == ".txt")
                    {
                        using (StreamWriter writer = new StreamWriter(fileName))
                        {
                            foreach (var emp in employeeList)
                            {
                                writer.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary}, Age: {emp.Age}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unsupported file format. Use .json or .txt");
                        return;
                    }
                    Console.WriteLine("Saved successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Save failed: {ex.Message}");
                }
            }

            void LoadFromFile()
            {
                try
                {
                    Console.Write("Enter file name to load ( data.json or data.txt): ");
                    string fileName = Console.ReadLine();
                    string extension = Path.GetExtension(fileName).ToLower();


                    if (!File.Exists(fileName))
                    {
                        Console.WriteLine("File not found.");
                        return;
                    }

                    if (extension == ".json")
                    {
                        string json = File.ReadAllText(fileName);
                        employeeList = JsonSerializer.Deserialize<List<Employee>>(json);
                    }
                    else if (extension == ".txt")
                    {
                        var loadedList = new List<Employee>();
                        foreach (var line in File.ReadLines(fileName))
                        {
                            var parts = line.Split(',');
                            if (parts.Length == 3 &&
                                int.TryParse(parts[0], out int id) &&
                                float.TryParse(parts[2], out float salary))
                            {
                                loadedList.Add(new Employee { Id = id, Name = parts[1], Salary = salary });
                            }
                        }
                        employeeList = loadedList;
                    }
                    else
                    {
                        Console.WriteLine("Unsupported file format. Use .json or .txt");
                        return;
                    }
                    Console.WriteLine("Loaded successfully.");
                  
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Load failed: {ex.Message}");
                }
            }

            static void ExitMethod()
            {
                Console.WriteLine("Exiting program. !");
            }

            #endregion

        }


      
    }
}
