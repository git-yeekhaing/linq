using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {ID = 101, FirstName = "Preety", LastName = "Tiwary", Salary = 60000 },
                new Employee {ID = 102, FirstName = "Priyanka", LastName = "Dewangan", Salary = 70000 },
                new Employee {ID = 103, FirstName = "Hina", LastName = "Sharma", Salary = 80000 },
                new Employee {ID = 104, FirstName = "Anurag", LastName = "Mohanty", Salary = 90000 },
                new Employee {ID = 105, FirstName = "Sambit", LastName = "Satapathy", Salary = 100000 },
                new Employee {ID = 106, FirstName = "Sushanta", LastName = "Jena", Salary = 160000 }
            };
            return employees;
        }

        public string Name { get; set; }
        public string Gender { get; set; }
        public List<string> Technology { get; set; }

        public static List<Employee> GetEmployeesComplex()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee {ID = 101, Name = "Preety", Gender = "Female", Salary = 60000,
                              Technology = new List<string>() {"C#", "Jave", "C++"} },
                new Employee {ID = 102, Name = "Priyanka", Gender = "Female", Salary = 50000,
                              Technology =new List<string>() { "WCF", "SQL Server", "C#" } },
                new Employee {ID = 103, Name = "Hina", Gender = "Female", Salary = 40000,
                              Technology =new List<string>() { "MVC", "Jave", "LINQ"}},
                new Employee {ID = 104, Name = "Anurag", Gender = "Male", Salary = 450000},
                new Employee {ID = 105, Name = "Sambit", Gender = "Male", Salary = 550000},
                new Employee {ID = 106, Name = "Sushanta", Gender = "Male", Salary = 700000,
                             Technology =new List<string>() { "ADO.NET", "C#", "LINQ" }}
            };
            return employees;
        }


    }
}
