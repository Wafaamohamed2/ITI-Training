using Day10.Models;
using Day10.Services;
using Microsoft.EntityFrameworkCore;

namespace Day10
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using var context = new AppDBContext();


           
           

            var addService = new AddService(context);
            var editService = new EditService(context);
            var deleteService = new DeleteService(context);
            var displayService = new DisplayService(context);


            string[] menuItems = { "Add", "Edite", "Delete", "Display", "Exit" };
            int X = Console.WindowWidth / 2;
            int Y = Console.WindowHeight / 4;
            int highlight = 0;
            bool Loop = true;


            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.BackgroundColor = (i == highlight) ? ConsoleColor.DarkCyan : ConsoleColor.Black;
                    Console.SetCursorPosition(X, Y + i);
                    Console.WriteLine(menuItems[i]);
                }

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        highlight = (highlight == 0) ? menuItems.Length - 1 : highlight - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        highlight = (highlight == menuItems.Length - 1) ? 0 : highlight + 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (highlight)
                        {
                            case 0:
                                AddMenu(addService);
                                break;
                            case 1:
                                EditMenu(editService);
                                break;
                            case 2:
                                DeleteMenu(deleteService);
                                break;
                            case 3:
                                displayService.DisplayMenu();
                                break;
                            case 4:
                                Console.WriteLine("Exiting...");
                                Loop = false;
                                break;
                        }
                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;
                }

            }
            while (Loop);

        }


        static void AddMenu(AddService addService)
        {
            Console.WriteLine("Add Menu:\n" +
                              "---------\n" +
                              "1. Employee\n" +
                              "2. Department\n" +
                              "3. Project\n");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    addService.AddEmployee();
                    break;
                case "2":
                    addService.AddDepartment();
                    break;
                case "3":
                    addService.AddProject();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void EditMenu(EditService editService)
        {
            Console.WriteLine("Edit Menu:\n" +
                              "---------\n" +
                              "1. Update Employee\n" +
                              "2. Update Department\n" +
                              "3. Update Project\n" +
                              "4. Assign Employee to Department\n" +
                              "5. Assign Employee to Project\n" +
                              "6. Remove Employee from Project\n");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Employee ID: ");
                    if (int.TryParse(Console.ReadLine(), out int empId))
                    {
                        Console.Write("Enter New Full Name: ");
                        string fullName = Console.ReadLine();


                        Console.Write("Enter New Department ID: ");
                        if (int.TryParse(Console.ReadLine(), out int deptId))
                        {
                            var employee = new Employee { Id = empId, FullName = fullName, DepartmentId = deptId };
                            editService.UpdateEmployee(employee);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Department ID.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid Employee ID.");
                    }
                    break;

                case "2":
                    Console.Write("Enter Department ID: ");
                    if (int.TryParse(Console.ReadLine(), out int deptId2))
                    {
                        Console.Write("Enter New Department Name: ");
                        string deptName = Console.ReadLine();
                        var department = new Department { Id = deptId2, Name = deptName };
                        editService.UpdateDepartment(department);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Department ID.");
                    }
                    break;

                case "3":
                    Console.Write("Enter Project ID: ");
                    if (int.TryParse(Console.ReadLine(), out int projId))
                    {
                        Console.Write("Enter New Project Name: ");
                        string projName = Console.ReadLine();
                        var project = new Projects { Id = projId, Name = projName };
                        editService.UpdateProject(project);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Project ID.");
                    }
                    break;

                case "4":
                    Console.Write("Enter Employee ID: ");
                    if (int.TryParse(Console.ReadLine(), out int empIdForDept))
                    {
                        Console.Write("Enter New Department ID: ");
                        if (int.TryParse(Console.ReadLine(), out int newDeptId))
                        {
                            editService.AssignEmployeeDepartment(empIdForDept, newDeptId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Department ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Employee ID.");
                    }
                    break;

                case "5":
                    Console.Write("Enter Employee ID: ");
                    if (int.TryParse(Console.ReadLine(), out int empIdForProj))
                    {
                        Console.Write("Enter Project ID: ");
                        if (int.TryParse(Console.ReadLine(), out int projIdForEmp))
                        {
                            editService.AssignEmployeeProject(empIdForProj, projIdForEmp);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Project ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Employee ID.");
                    }
                    break;

                case "6":
                    Console.Write("Enter Employee ID: ");
                    if (int.TryParse(Console.ReadLine(), out int empIdToRemove))
                    {
                        Console.Write("Enter Project ID: ");
                        if (int.TryParse(Console.ReadLine(), out int projIdToRemove))
                        {
                            editService.RemoveEmployeeFromProject(empIdToRemove, projIdToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Project ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Employee ID.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;

            }
        }

        static void DeleteMenu(DeleteService deleteService)
        {
            Console.WriteLine("Delete Menu:\n" +
                              "---------\n" +
                              "1. Delete Employee\n" +
                              "2. Delete Department\n" +
                              "3. Delete Project\n");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    deleteService.DeleteEmplioyee();
                    break;
                case "2":
                    deleteService.DeleteDepartment();
                    break;
                case "3":
                    deleteService.DeleteProject();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}