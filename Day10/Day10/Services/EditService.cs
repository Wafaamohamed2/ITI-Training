using Day10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Services
{
    public class EditService
    {

        private readonly AppDBContext context;

        public EditService(AppDBContext db)
        {
            context = db;
        }  
        
        private void UpdateAndSave<T>(T entity, string successMessage) where T : class
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
            Console.WriteLine(successMessage);
        }


        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = context.Employees.
                FirstOrDefault(e =>e.Id == employee.Id);

            // Check if the employee exists
            if (existingEmployee != null)
            {
                existingEmployee.FullName = employee.FullName;
              
                existingEmployee.DepartmentId = employee.DepartmentId;

                UpdateAndSave(existingEmployee, "Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void UpdateDepartment(Department department)
        {
            var existingDepartment = context.Departments
                .FirstOrDefault(d => d.Id == department.Id);

            // Check if the department exists
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;

                UpdateAndSave(existingDepartment, "Department updated successfully.");
            }
            else
            {
                Console.WriteLine("Department not found.");
            }
        }

        public void AssignEmployeeDepartment(int employeeId, int newDepartmentId)
        {
            var employee = context.Employees
                .FirstOrDefault(e => e.Id == employeeId);

            // Check if the employee exists
            if (employee != null)
            {
                // Check if the new department exists
                var newDepartment = context.Departments
                    .FirstOrDefault(d => d.Id == newDepartmentId);

                if (newDepartment != null)
                {
                    employee.DepartmentId = newDepartmentId;


                    UpdateAndSave(employee, "Employee's department updated successfully.");
                }
                else
                {
                    Console.WriteLine("New department not found.");
                }
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }



        public void UpdateProject(Projects project)
        {
            var existingProject = context.Projects
                .FirstOrDefault(p => p.Id == project.Id);

            // Check if the project exists
            if (existingProject != null)
            {
                existingProject.Name = project.Name;

                UpdateAndSave(existingProject, "Project updated successfully.");
            }
            else
            {
                Console.WriteLine("Project not found.");
            }
        }

        public void AssignEmployeeProject(int employeeId, int projectId)
        {
            var employee = context.Employees.Find(employeeId);
            var project = context.Projects.Find(projectId);

            if (employee == null || project == null)
            {
                Console.WriteLine("Employee or Project not found.");
                return;
            }

            var exists = context.EmployeeProjects
                .Any(ep => ep.EmployeeId == employeeId && ep.ProjectId == projectId);

            if (exists)
            {
                Console.WriteLine("Employee is already assigned to this project.");
            }

            else
            {
                var employeeProject = new EmployeeProject
                {
                    EmployeeId = employeeId,
                    ProjectId = projectId
                };

                context.EmployeeProjects.Add(employeeProject);
                context.SaveChanges();

                Console.WriteLine("Employee assigned to project successfully.");
            }
        }

        public void RemoveEmployeeFromProject(int employeeId , int projectId)
        {
            
                var employeeProject = context.EmployeeProjects
                    .FirstOrDefault(ep => ep.EmployeeId == employeeId && ep.ProjectId == projectId);

                if (employeeProject != null)
                {
                    context.EmployeeProjects.Remove(employeeProject);
                    context.SaveChanges();

                    Console.WriteLine( "Employee removed from project successfully.");
                }
                else
                {
                    Console.WriteLine("Employee is not assigned to this project.");
                }

    
        }
    }
}
