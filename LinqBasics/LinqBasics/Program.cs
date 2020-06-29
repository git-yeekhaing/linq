﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    // Example: We have an integer list and we need to write a LINQ query which will return all the integers which are greater than 5.
    // We are going to create a console application.
    class Program
    {
        static void Main(string[] args)
        {
            // Example1:
            // Select all the data from the data source using both Method and Query Syntax.
            LinqSelectOperator();
            Console.WriteLine("\n==============================");

            // Example2:
            LinqSelectOperatorEx2();
            Console.WriteLine("\n==============================");

            // Example3:
            LinqSelectOperatorEx3();
            Console.WriteLine("\n==============================");

            // Example4:
            LinqSelectOperatorEx4();
            Console.WriteLine("\n==============================");

            // Example5:
            LinqSelectOperatorEx5();
            Console.WriteLine("\n==============================");

            // Example6:
            LinqSelectOperatorEx6();
            Console.WriteLine("\n==============================");

            // Example7:
            LinqSelectOperatorEx7();
            Console.WriteLine("\n==============================");

            string sentence = "Welcome to Dotnet Tutorials";
            int wordCount = sentence.GetWordCount();
            Console.WriteLine($"Count : {wordCount}");
            Console.WriteLine("\n==============================");

            LinqQuerySyntax();
            Console.WriteLine("\n==============================");

            LinqMethodSyntax();
            Console.WriteLine("\n==============================");

            LinqMixedSyntax();
            Console.WriteLine("\n==============================");

            IEnumerableSyntax();
            Console.WriteLine("\n==============================");

            // C# IEnumerable with complex type
            IEnumerableWithComplexType();
            Console.WriteLine("\n==============================");

            IQueryableWithComplexType();
            Console.WriteLine("\n==============================");

            Console.ReadKey();
        }

        private static void LinqSelectOperatorEx7()
        {
            // QuerySyntax
            var query = (from emp in Employee.GetEmployees()
                         .Select((value, index) => new { value, index })
                         select new
                         {
                             IndexPosition = emp.index,
                             FullName = emp.value.FirstName + " " + emp.value.LastName,
                             Salary = emp.value.Salary
                         }).ToList();

            foreach (var emp in query)
            {
                Console.WriteLine($" Position {emp.IndexPosition} Name : {emp.FullName} Salary : {emp.Salary} ");
            }

            // Method Syntax
            var selectMethod = Employee.GetEmployees().
                                        Select((emp, index) => new
                                        {
                                            IndexPosition = index,
                                            FullName = emp.FirstName + " " + emp.LastName,
                                            Salary = emp.Salary
                                        });

            foreach (var emp in selectMethod)
            {
                Console.WriteLine($" Position {emp.IndexPosition} Name : {emp.FullName} Salary : {emp.Salary} ");
            }
        }

        private static void LinqSelectOperatorEx6()
        {
            // Query Syntax
            var selectQuery = (from emp in Employee.GetEmployees()
                               select new
                               {
                                   EmployeeId = emp.ID,
                                   FullName = emp.FirstName + " " + emp.LastName,
                                   AnnualSalary = emp.Salary * 12
                               });

            foreach (var emp in selectQuery)
            {
                Console.WriteLine($" ID {emp.EmployeeId} Name : {emp.FullName} Annual Salary : {emp.AnnualSalary} ");
            }

            // Method Syntax
            var selectMethod = Employee.GetEmployees()
                .Select(emp => new
                {
                    EmployeeId = emp.ID,
                    FullName = emp.FirstName + " " + emp.LastName,
                    AnnualSalary = emp.Salary * 12
                });

            foreach (var emp in selectMethod)
            {
                Console.WriteLine($" ID {emp.EmployeeId} Name : {emp.FullName} Annual Salary : {emp.AnnualSalary} ");
            }
        }

        private static void LinqSelectOperatorEx5()
        {
            // Query Syntax
            var selectQuery = (from emp in Employee.GetEmployees()
                               select new
                               {
                                    FirstName = emp.FirstName,
                                    LastName = emp.LastName,
                                    Salary = emp.Salary
                               });

            foreach (var emp in selectQuery)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }

            // Method Syntax
            var selectMethod = Employee.GetEmployees()
                .Select(emp => new
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Salary = emp.Salary
                });

            foreach (var emp in selectMethod)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }
        }

        private static void LinqSelectOperatorEx4()
        {
            // Query Syntax
            IEnumerable<EmployeeBasicInfo> selectQuery = (from emp in Employee.GetEmployees()
                                                          select new EmployeeBasicInfo()
                                                          {
                                                              FirstName = emp.FirstName,
                                                              LastName = emp.LastName,
                                                              Salary = emp.Salary
                                                          });

            foreach (var emp in selectQuery)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }

            // Method Syntax
            List<EmployeeBasicInfo> selectMethod = Employee.GetEmployees()
                .Select(emp => new EmployeeBasicInfo()
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Salary = emp.Salary
                }).ToList();

            foreach (var emp in selectMethod)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }
        }

        private static void LinqSelectOperatorEx3()
        {
            // Query Syntax
            IEnumerable<Employee> selectQuery = (from emp in Employee.GetEmployees()
                                                 select new Employee()
                                                 {
                                                     FirstName = emp.FirstName,
                                                     LastName = emp.LastName,
                                                     Salary = emp.Salary
                                                 }) ;

            foreach (var emp in selectQuery)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }

            // Method Syntax
            List<Employee> selectMethod = Employee.GetEmployees()
                .Select(emp => new Employee()
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Salary = emp.Salary
                }).ToList();

            foreach (var emp in selectMethod)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }
        }

        private static void LinqSelectOperatorEx2()
        {
            // Query syntax
            List<int> basicPropQuery = (from emp in Employee.GetEmployees()
                                        select emp.ID).ToList();

            foreach (var id in basicPropQuery)
            {
                Console.WriteLine($"ID : {id}");
            }

            Console.WriteLine("\n==============================");
            // Method Syntax
            IEnumerable<int> basicPropMethod = Employee.GetEmployees()
                .Select(emp => emp.ID);

            foreach (var id in basicPropMethod)
            {
                Console.WriteLine($"ID : {id}");
            }
        }

        private static void LinqSelectOperator()
        {
            // Query syntax
            List<Employee> basicQuery = (from emp in Employee.GetEmployees()
                                         select emp).ToList();

            foreach (Employee emp in basicQuery)
            {
                Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} {emp.LastName}");
            }
            Console.WriteLine("\n==============================");

            // Method Syntax
            IEnumerable<Employee> basicMethod = Employee.GetEmployees().ToList();
            foreach (Employee emp in basicMethod)
            {
                Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} {emp.LastName}");
            }
        }

        private static void IEnumerableSyntax()
        {
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            IEnumerable<int> QuerySyntax = from obj in integerList
                                           where obj > 5
                                           select obj;

            foreach (var item in QuerySyntax)
            {
                Console.Write(item + " ");
            }
        }

        private static void IEnumerableWithComplexType()
        {
            List<Student> studList = new List<Student>()
            {
                new Student(){ID = 1, Name = "James", Gender = "Male"},
                new Student(){ID = 2, Name = "Sara", Gender = "Female"},
                new Student(){ID = 3, Name = "Steve", Gender = "Male"},
                new Student(){ID = 4, Name = "Pam", Gender = "Female"}
            };

            // Linq Query to Fetch all students with Gender Male
            IEnumerable<Student> QuerySyntax = from std in studList
                                               where std.Gender == "Male"
                                               select std;

            // Iterate through the collection
            foreach (var student in QuerySyntax)
            {
                Console.WriteLine($"ID : {student.ID}  Name : {student.Name}");
            }
        }

        private static void IQueryableWithComplexType()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student() { ID = 1, Name = "James", Gender = "Male" },
                new Student() { ID = 2, Name = "Sara", Gender = "Female" },
                new Student() { ID = 3, Name = "Steve", Gender = "Male" },
                new Student() { ID = 4, Name = "Pam", Gender = "Female" }
            };

            //Linq Query to Fetch all students with Gender Male
            IQueryable<Student> MethodSyntax = studentList.AsQueryable()
                                                 .Where(std => std.Gender == "Male");

            //Iterate through the collection
            foreach (var student in MethodSyntax)
            {
                Console.WriteLine($"ID : {student.ID}  Name : {student.Name}");
            }
        }

        private static void LinqQuerySyntax()
        {
            // data source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            // linq query using query syntax
            var QuerySyntax = from obj in integerList
                              where obj > 5
                              select obj;

            // Execution
            foreach (var item in QuerySyntax)
            {
                Console.Write(item + " ");
            }
        }

        private static void LinqMethodSyntax()
        {
            //Data Source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            //LINQ Query using Method Syntax
            var methodSyntax = integerList.Where(obj => obj > 5).ToList();

            // Execution
            foreach (var item in methodSyntax)
            {
                Console.Write(item + " ");
            }
        }

        private static void LinqMixedSyntax()
        {
            //Data Source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            // mixed syntax
            var mixsyntax = (from obj in integerList
                             where obj > 5
                             select obj).Sum();

            //Execution
            Console.Write("Sum Is : " + mixsyntax);
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}