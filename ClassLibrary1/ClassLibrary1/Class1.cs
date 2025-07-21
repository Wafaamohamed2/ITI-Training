namespace ClassLibrary1
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Salary { get; set; }
        

        public int _age;

        // Property with validation
        public int Age { 
            get { return _age;}

            set { 
                if (value < 18 || value >60)
                {
                    throw new ArgumentException("Age must be between 18 and 60");
                }
                _age = value;
            }
            
        }
       

        public Employee() : this(0, "Unknown", 0.0f, 25) { }

        public Employee(int id, string name, float salary, int age)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Age = age;
        }

        public void DisplayData()
        {
            Console.WriteLine($"ID      : {Id}");
            Console.WriteLine($"Name    : {Name}");
            Console.WriteLine($"Salary  : {Salary}");
            Console.WriteLine($"Age     : {Age}");
        }
    }
    public class SortByIdAsc : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) => x.Id.CompareTo(y.Id);
    }

    public class SortByIdDesc : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) => y.Id.CompareTo(x.Id);
    }
    public class SortByName : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) => x.Name.CompareTo(y.Name);
    }

    public class SortBySalary : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) => x.Salary.CompareTo(y.Salary);
    }

}
