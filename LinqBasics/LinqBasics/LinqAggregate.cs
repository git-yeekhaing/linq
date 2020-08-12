using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class LinqAggregate
    {
        public static void Example1()
        {
            string[] skills = { "C#.NET", "MVC", "WCF", "SQL", "LINQ", "ASP.NET" };

            string result = skills.Aggregate((s1,s2) => s1 + "," + s2);

            Console.WriteLine(result);

            Console.WriteLine("================Finish============");
        }

        public static void Example2()
        {
            int[] intNumbers = { 3, 5, 7, 9 };

            int result = intNumbers.Aggregate((n1, n2) => n1 * n2);

            Console.WriteLine(result);

            Console.WriteLine("================Finish============");
        }

        public static void Example3()
        {
            int[] intNumbers = { 3, 5, 7, 9 };

            int result = intNumbers.Aggregate(2, (n1, n2) => n1 * n2);

            Console.WriteLine(result);

            Console.WriteLine("================Finish============");
        }

        public static void ComplexExample1()
        {
            int salary = Employee2.GetAllEmployees()
                .Aggregate<Employee2, int>(0, (TotalSalary, emp) => TotalSalary += emp.Salary);

            Console.WriteLine(salary);

            Console.WriteLine("================Finish============");
        }

        public static void ComplexExample2()
        {
            string CommaSeparatedEmployeeNames = Employee2.GetAllEmployees().Aggregate<Employee2, string, string>(
                                                    "Employee Names : ",  // seed value
                                                    (employeeNames, employee) => employeeNames = employeeNames + employee.Name + ",",
                                                    employeeNames => employeeNames.Substring(0, employeeNames.Length - 1));


            CommaSeparatedEmployeeNames = Employee2.GetAllEmployees().Aggregate<Employee2, string, string>("Emp Names: ",
                (result, emp) => result = result + emp.Name + ",", 
                result => result.Substring(0, result.Length - 1));

            Console.WriteLine("================Finish============");
        }

        public static void Template()
        {
           

            Console.WriteLine("================Finish============");
        }
    }
}
