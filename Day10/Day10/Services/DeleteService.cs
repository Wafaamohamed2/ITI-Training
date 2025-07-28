using Day10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Services
{
    public class DeleteService
    {
        private readonly AppDBContext context;

        public DeleteService(AppDBContext db)
        {
            context = db;
        }

        static void DeleteAndSave<T>(T entity, string successMessage) where T : class
        {
            using var context = new AppDBContext();
            context.Set<T>().Remove(entity);
            context.SaveChanges();
            Console.WriteLine(successMessage);
        }


        public void DeleteEmplioyee()
        {
            Console.WriteLine("Enter Employee ID to delete: ");
            int employeeId = int.Parse(Console.ReadLine());


            var employee = context.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (employee != null)
            {

               

                DeleteAndSave(employee, "Employee deleted successfully.");

            }
        }

        public void DeleteDepartment()
        {
            Console.WriteLine("Enter Department ID to delete: ");
            int departmentId = int.Parse(Console.ReadLine());

            var department = context.Departments.FirstOrDefault(d => d.Id == departmentId);
            if (department != null)
            {
                // Check if the department has employees
                if (department.Employees.Any())
                {
                    Console.WriteLine("Cannot delete department with existing employees.");
                    return;
                }

                DeleteAndSave(department, "Department deleted successfully.");
            }
        }

        public void DeleteProject()
        {
            Console.WriteLine("Enter Project ID to delete: ");
            int projectId = int.Parse(Console.ReadLine());

            var project = context.Projects.FirstOrDefault(p => p.Id == projectId);
            if (project != null)
            {
                // Check if the project has employees
                if (project.EmployeeProjects.Any())
                {
                    Console.WriteLine("Cannot delete project with existing employees.");
                    return;
                }

                DeleteAndSave(project, "Project deleted successfully.");
            }
        }
    }

    
}
