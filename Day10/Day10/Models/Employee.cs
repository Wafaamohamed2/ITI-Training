using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public decimal Salary { get; set; }
     

        // Foreign key for Department
        public int? DepartmentId { get; set; } // Nullable to allow for employees without a department
        


        // Navigation properties
        public Department Department { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

        
       
    }
}
