using Day10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Day10.Services
{
    public class DisplayService
    {

        private readonly AppDBContext context;

        public DisplayService(AppDBContext db)
        {
            context = db;
        }

        public void DisplayMenu()
        {
            

            Console.WriteLine("\n==Display Menu==\n" +
                "----------------\n" +
                "1. Employees\n"+
                "2. Departments\n"+
                "3. Projects\n");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();



            switch (choice)
            {
                case "1":
                    
                    var employees = context.Employees.Include(e => e.Department)
                        .Include(e =>e.EmployeeProjects)
                        .ThenInclude(e =>e.Project)
                        .ToList();



                    Console.WriteLine("\n-- Employees --");
                    foreach (var emp in employees) { 
                        
                        Console.WriteLine($"{emp.Id}. {emp.FullName}");

                        if (emp.Department != null) { Console.WriteLine($"   Department: {emp.Department.Name}"); }
                        else Console.WriteLine("   Department: Not Assigned");

                        if (emp.EmployeeProjects.Any())
                        {
                            Console.WriteLine("   Projects:");
                            foreach (var ep in emp.EmployeeProjects)
                            {
                                Console.WriteLine($"             - {ep.Project.Name}\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("   Projects: None\n");
                        }
                    }
                       
                        
                    break;

                case "2":

                    var departments = context.Departments
                        .Include(d => d.Employees).ToList();

                    Console.WriteLine("\n-- Departments --");
                   

                    foreach (var dept in departments)
                    {

                        Console.WriteLine($"{dept.Id} - {dept.Name}");
                        if (dept.Employees.Any())
                        {

                            foreach (var employee in dept.Employees)
                            {
                                Console.WriteLine($"\t- Employee: {employee.FullName} ");
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
                   
                    var projects = context.Projects
                        .Include(p => p.EmployeeProjects)
                        .ThenInclude(ep => ep.Employee).ToList();

                    Console.WriteLine("\n-- Projects --");

                    foreach (var proj in projects)
                    {
                        Console.WriteLine($"{proj.Id} - {proj.Name}");
                        if (proj.EmployeeProjects.Any())
                        {
                            Console.WriteLine("   Assigned Employees:");
                            foreach (var employee in proj.EmployeeProjects)
                            {
                                Console.WriteLine($"\t-  {employee.Employee.FullName}  ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\t- No employees assigned to this project.");
                        }
                        Console.WriteLine("----------------------------");

                    }



                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }




    }
}
