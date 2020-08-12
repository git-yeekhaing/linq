using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{

    public class Employee2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }

        public static List<Employee2> GetAllEmployees()
        {
            List<Employee2> listStudents = new List<Employee2>()
            {
                new Employee2{ID= 101,Name = "Preety", Salary = 10000, Department = "IT"},
                new Employee2{ID= 102,Name = "Priyanka", Salary = 15000, Department = "Sales"},
                new Employee2{ID= 103,Name = "James", Salary = 50000, Department = "Sales"},
                new Employee2{ID= 104,Name = "Hina", Salary = 20000, Department = "IT"},
                new Employee2{ID= 105,Name = "Anurag", Salary = 30000, Department = "IT"},

            };

            return listStudents;
        }
    }
}