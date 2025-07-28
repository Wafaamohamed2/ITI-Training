using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        // Navigation properties
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

       

    }
}
