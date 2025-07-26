using Day_9.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_9
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string[] menuItems = { "Add", "Display", "Exit" };
            int X = Console.WindowWidth / 2;
            int Y = Console.WindowHeight / 4;
            int hight = 0;
            bool Loop = true;


            do
            {
                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.BackgroundColor = (i == hight) ? ConsoleColor.DarkCyan : ConsoleColor.Black;
                    Console.SetCursorPosition(X, Y + i);
                    Console.WriteLine(menuItems[i]);
                }

                ConsoleKeyInfo k = Console.ReadKey();

                switch (k.Key)
                {
                    case ConsoleKey.DownArrow:
                        hight = (hight + 1) % menuItems.Length;
                        break;
                    case ConsoleKey.UpArrow:
                        hight = (hight - 1 + menuItems.Length) % menuItems.Length;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (hight)
                        {
                            case 0:
                                AddMenu();
                                break;
                            case 1:
                                DisplayMenu();
                                break;
                            case 2:
                                Console.WriteLine("Exiting...");
                                Loop = false;
                                break;
                        }
                        break;
                }
            } while (Loop);


        }


        static void AddMenu()
        {
            Console.WriteLine("Add Menu:\n " + "---------\n" +
                "1. Employee\n2. Department\n3. Project\n");
            Console.Write("Enter choice:\n" + "---------------\n");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    AddDepartment();
                    break;
                case "3":
                    AddProject();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void DisplayMenu()
        {
            using var context = new CompanyContext();

            Console.WriteLine("\n==Display Menu:==\n1" + "----------------\n" +
                "1. Employees\n2. Departments\n3. Projects\n");
            Console.Write("Enter choice: " );
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var employees = context.Employees
                        .Include(e=>e.Department).ToList();

                    Console.WriteLine("\n-- Employees --");
                    foreach (var emp in employees)
                        Console.WriteLine($"{emp.EmployeeId}.  {emp.FirstName } { emp.LastName} is in Department:-   {emp.Department.Name}");
                    break;

                case "2":
                    Console.WriteLine("\n-- Departments --");
                    var departments = context.Departments
                        .Include(d => d.Employees).ToList();    

                    foreach (var dept in departments) {  
                        
                        Console.WriteLine($"{dept.DepartmentId} - {dept.Name}");
                        if(dept.Employees.Any()) {

                            foreach (var employee in dept.Employees)
                            {
                                Console.WriteLine($"\t- Employee: {employee.FirstName} {employee.LastName} ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\t- No employees in this department.");
                        }
                        Console.WriteLine("----------------------------");

                    }


                break;

                case "3":
                    Console.WriteLine("\n-- Projects --");
                    var projects = context.Projects
                        .Include(p => p.EmployeeProjects)
                        .ThenInclude(ep => ep.Employee).ToList();

                    foreach (var proj in projects) {
                        Console.WriteLine($"{proj.ProjectId} - {proj.Name}");
                        if (proj.EmployeeProjects.Any())
                        {

                            foreach (var employee in proj.EmployeeProjects)
                            {
                                Console.WriteLine($"\t- Employee: {employee.Employee.FirstName} {employee.Employee.LastName} ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\t- No employees in this department.");
                        }
                        Console.WriteLine("----------------------------");

                    }
                        

                       
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }




        // // Generic method to add and save an entity to avoid code duplication
        static void AddAndSave<T>(T entity, string successMessage) where T : class
        {
            using var context = new CompanyContext();
            context.Set<T>().Add(entity);
            context.SaveChanges();
            Console.WriteLine(successMessage);
        }




        static void AddEmployee()
        {
            using (var context = new CompanyContext())
            {
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter Department ID: ");
                int departmentId = int.Parse(Console.ReadLine());

                // Check if the department exists
                var department = context.Departments.Find(departmentId);
                if (department == null)
                {
                    Console.WriteLine("Department not found. Please add the department first.");
                    return;
                }

                var employee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DepartmentId = departmentId
                };

                //context.Employees.Add(employee);
                //context.SaveChanges();
                //Console.WriteLine("Employee added successfully.");

                AddAndSave(employee, "Employee added successfully.");
            }
        }

        static void AddDepartment()
        {
            using (var context = new CompanyContext())
            {
                Console.Write("Enter Department Name: ");
                string name = Console.ReadLine();



                var department = new Department
                {
                    Name = name
                };

                //context.Departments.Add(department);
                //context.SaveChanges();
                //Console.WriteLine("Department added successfully.");

                AddAndSave(department, "Department added successfully.");
            }

        }

        static void AddProject()
        {
            using (var context = new CompanyContext())
            {
                Console.Write("Enter Project Name: ");
                string name = Console.ReadLine();

                var project = new Project
                {
                    Name = name
                };

                //context.Projects.Add(project);
                //context.SaveChanges();
                //Console.WriteLine("Project added successfully.");

                AddAndSave(project, "Project added successfully.");
            }
        }

   

    }
}
