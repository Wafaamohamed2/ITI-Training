using Day10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Services
{
    public class AddService
    {

        public readonly AppDBContext context;

        public AddService(AppDBContext db)
        {
            context = db;
        }

        static void AddAndSave<T>(T entity, string successMessage) where T : class
        {
            using var context = new AppDBContext();
            context.Set<T>().Add(entity);
            context.SaveChanges();
            Console.WriteLine(successMessage);
        }



        public void AddEmployee()
        {
           
                Console.Write("Enter Your Name: ");
                string FullName = Console.ReadLine();

                

                Console.Write("Enter Department ID: ");
                int departmentId = int.Parse(Console.ReadLine());


                // Check if the department exists
                var department =context.Departments
                    .FirstOrDefault(d => d.Id == departmentId);
                if (department == null)
                {
                    Console.WriteLine("Department not found. Please add the department first.");
                    return;
                }

                var employee = new Employee
                {
                    FullName = FullName ,
                    DepartmentId = departmentId
                };

            AddAndSave(employee, "Employee added successfully.");

        }

        public void AddDepartment()
        {
            Console.Write("Enter Department Name: ");
            string name = Console.ReadLine();


             if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Department name cannot be empty.");
                return;
            }

            var department = new Department
            {
                Name = name
                
            };
           

             AddAndSave(department, "Department added successfully.");
        }
        
        public void AddProject()
        {
            Console.Write("Enter Project Name: ");
            string name = Console.ReadLine();

            var project = new Projects
            {
                Name = name
            };

            AddAndSave(project, "Project added successfully.");
        }

    }
}
