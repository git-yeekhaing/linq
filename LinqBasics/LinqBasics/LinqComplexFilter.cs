using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class LinqComplexFilter
    {
        // We need to fetch all the employees whose salary is greater than 50000.
        public static void GetEmpWithSalaryOver50000()
        {
            // query syntax
            var QuerySyntax = from employee in Employee.GetEmployeesComplex()
                              where employee.Salary > 50000
                              select employee;
            // method syntax
            var methodSyntax = Employee.GetEmployees()
                .Where(emp => emp.Salary > 50000);

            foreach (var emp in QuerySyntax)
            {
                Console.WriteLine($"Name : {emp.Name}, Salary : {emp.Salary}, Gender : {emp.Gender}");
                if (emp.Technology != null && emp.Technology.Count() > 0)
                {
                    Console.Write(" Technology : ");
                    foreach (var tech in emp.Technology)
                    {
                        Console.Write(tech + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(" Technology Not Available ");
                }
            }
        }

        // We need to fetch all the employee whose gender is Male 
        // and Salary is greater than 500000.
        public static void GetEmpWithMaleSalaryOver50000()
        {
            // query syntax
            var querySyntax = from employee in Employee.GetEmployeesComplex()
                              where employee.Salary > 50000 && employee.Gender == "Male"
                              select employee;

            // method syntax
            var methodSyntax = Employee.GetEmployeesComplex()
                .Where(emp => emp.Salary > 50000 && emp.Gender == "Male").ToList();

            foreach (var emp in methodSyntax)
            {
                Console.WriteLine($"Name : {emp.Name}, Salary : {emp.Salary}, Gender : {emp.Gender}");
                if (emp.Technology != null && emp.Technology.Count() > 0)
                {
                    Console.Write(" Technology : ");
                    foreach (var tech in emp.Technology)
                    {
                        Console.Write(tech + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(" Technology Not Available ");
                }
            }
        }

        /* All the employees whose salary is greater than or equal to 50000 
         and technology should not be null.
        We need to fetch the following information to an anonymous type.
        Name as it is
        Gender as it is
        MonthlySalary = Salary / 12*/
        public static void GetComplexType()
        {
            // query syntax
            var querySyntax = (from employee in Employee.GetEmployeesComplex()
                               where employee.Salary >= 50000 && employee.Technology != null
                               select new
                               {
                                   EmpName = employee.Name,
                                   Gender = employee.Gender,
                                   MonthlySalary = employee.Salary / 12
                               }).ToList();

            // method Syntax
            var methodSyntax = Employee.GetEmployeesComplex()
                .Where(emp => emp.Salary >= 50000 && emp.Technology != null)
                .Select(emp => new
                {
                    EmpName = emp.Name,
                    Gender = emp.Gender,
                    MonthlySalary = emp.Salary / 12
                }).ToList();

            foreach (var emp in querySyntax)
            {
                Console.WriteLine($"Name : {emp.EmpName}, Gender : {emp.Gender}, Monthly Salary : {emp.MonthlySalary}");
            }
        }
        
        public static void FetchElementWithIndexPos()
        {
            // query syntax
            var querySyntax = (from data in Employee.GetEmployeesComplex()
                                   .Select((Data, index) => new {employee = Data, Index = index })
                                    where data.employee.Salary >= 500000 && data.employee.Gender == "Male"
                                    select new
                                    {
                                        EmployeeName = data.employee.Name,
                                        Gender = data.employee.Gender,
                                        Salary = data.employee.Salary,
                                        IndexPos = data.Index
                                    }
                               ).ToList();


            // method syntax
            var methodSyntax = Employee.GetEmployeesComplex()
                .Select((Data, index) => new { employee = Data, Index = index })
                .Where(emp => emp.employee.Salary >= 500000 && emp.employee.Gender == "Male")
                .Select(emp => new
                {
                    EmployeeName = emp.employee.Name,
                    Gender = emp.employee.Gender,
                    Salary = emp.employee.Salary,
                    IndexPos = emp.Index
                }).ToList();

            foreach (var emp in querySyntax)
            {
                Console.WriteLine($"Position : {emp.IndexPos} Name : {emp.EmployeeName}, Gender : {emp.Gender}, Salary : {emp.Salary}");
            }

        }
    }
}
