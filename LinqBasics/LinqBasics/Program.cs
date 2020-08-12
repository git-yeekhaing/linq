using System;
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
            #region Except
            LinqExcept.Example1();
            LinqExcept.Example2();
            LinqExcept.Example3();
            #endregion

            //#region Linq Distinct Operators
            //DistinctOperator.OnValueType();            
            //DistinctOperator.OnStringType();
            //DistinctOperator.OnStringCaseSensitive();
            //DistinctOperator.OnObjDistinct();
            //DistinctOperator.OnIEqualityComparer();
            //DistinctOperator.OnOverrideCompare();
            //#endregion

            /* #region Linq Set Operators
             LinqSetOperator.LinqDistinctMethod();
             LinqSetOperator.LinqDistinctMethod2();
             LinqSetOperator.LinqDistinctMethod3();
             LinqSetOperator.LinqDistinctWithComplexType();
             LinqSetOperator.LinqDistinctWithComplexType2();
             #endregion
            */

            #region OfType Operator in LINQ
            /*
            OfTypeOperator.ExampleOne();
            OfTypeOperator.ExampleTwo();
            OfTypeOperator.ExampleThree();
            */
            #endregion

            #region Filter
            /*
            FilterOperator();
            Console.WriteLine("\n==============================");

            FilterGenericDelegate();
            Console.WriteLine("\n==============================");

            FilterOperator2();
            Console.WriteLine("\n==============================");

            FilterOperator2WithQuery();
            Console.WriteLine("\n==============================");

            LinqComplexFilter.GetEmpWithSalaryOver50000();
            Console.WriteLine("\n==============================");

            LinqComplexFilter.GetEmpWithMaleSalaryOver50000();
            Console.WriteLine("\n==============================");

            LinqComplexFilter.GetComplexType();
            Console.WriteLine("\n==============================");

            LinqComplexFilter.FetchElementWithIndexPos();
            Console.WriteLine("\n==============================");
            */
            #endregion

            #region SelectMany
            /*
            SelectManyExample1();
            Console.WriteLine("\n==============================");

            SelectManyExample1WithQuery();
            Console.WriteLine("\n==============================");

            SelectManyExample2();
            Console.WriteLine("\n==============================");

            SelectManyExample3();
            Console.WriteLine("\n==============================");

            SelectManyExample4();
            Console.WriteLine("\n==============================");

            */
            #endregion

            #region Select Operator
            /*
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
            */
            #endregion

            #region LinqBasic
            /*
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

            */
            #endregion

            Console.ReadKey();
        }

        private static void FilterOperator2WithQuery()
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // query syntax
            var OddNumberWithIndexPosition = from num in intList
                                             .Select((num, index) =>
                                             new { Numbers = num, IndexPostion = index })
                                             where num.Numbers % 2 != 0
                                             select new
                                             {
                                                 Number = num.Numbers,
                                                 IndexPosition = num.IndexPostion
                                             };
        }

        //Here we need to filter only the odd numbers i.e. 
        //the numbers which are not divisible by 2.
        //Along with the numbers we also need to fetch the index position of the number. The index is 0 based.
        private static void FilterOperator2()
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Method syntax
            var OddNumbersWithIndexPosition = intList.Select((num, index) => 
            new
            {
                Numbers = num,
                IndexPositon = index
            }).Where(x => x.Numbers % 2 != 0)
            .Select(data => new
            {
                Number = data.Numbers,
                IndexPosition = data.IndexPositon
            });

            foreach (var item in OddNumbersWithIndexPosition)
            {
                Console.WriteLine($"IndexPosition :{item.IndexPosition} , Value : {item.Number}");
            }
        }

        private static void FilterGenericDelegate()
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // method syntax
            IEnumerable<int> filterData = intList.Where(num => CheckNumber(num));

            foreach (int number in filterData)
            {
                Console.WriteLine(number);
            }
        }

        public static bool CheckNumber(int number)
        {
            if (number > 5)
            {
                return true;
            }

            return false;
        }             

        private static void FilterOperator()
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // method syntax
            IEnumerable<int> filteredData = intList.Where(num => num > 5);

            // query syntax
            IEnumerable<int> filterResult = from num in intList
                                            where num > 5
                                            select num;

            foreach (int number in filteredData)
            {
                Console.WriteLine(number);
            }
        }

        // Now we need to retrieve the student name along with the program language name
        private static void SelectManyExample4()
        {
            // method syntax
            var methodSyntax = Student.GetStudents()
                .SelectMany(std => std.Programming,
                (student, program) => new
                {
                    StudentName = student.Name,
                    ProgrammingName = program
                }).ToList();

            // query syntax
            var querySyntax = (from std in Student.GetStudents()
                               from program in std.Programming
                               select new
                               {
                                   StudentName = std.Name,
                                   ProgramName = program
                               }).ToList();

            //Printing the values
            foreach (var item in querySyntax)
            {
                Console.WriteLine(item.StudentName + " => " + item.ProgramName);
            }
        }

        private static void SelectManyExample3()
        {
            // method syntax
            List<string> methodSyntax = Student.GetStudents()
                .SelectMany(std => std.Programming)
                .Distinct().ToList();

            // query syntax
            IEnumerable<string> querySyntax = (from std in Student.GetStudents()
                                               from program in std.Programming
                                               select program).Distinct().ToList() ;
            
            //Printing the values
            foreach (string program in querySyntax)
            {
                Console.WriteLine(program);
            }
        }

        private static void SelectManyExample2()
        {
            // method syntax
            List<string> MethodSyntax = Student.GetStudents().SelectMany(
                std => std.Programming).ToList();

            // query sytax
            IEnumerable<string> QuerySyntax = from std in Student.GetStudents()
                                              from program in std.Programming
                                              select program;

            // Printing the values
            foreach (string program in MethodSyntax)
            {
                Console.WriteLine(program);
            }
        }

        private static void SelectManyExample1WithQuery()
        {
            List<string> nameList = new List<string>() { "Pranaya", "Kumar" };

            IEnumerable<char> querySyntax = from str in nameList
                                            from ch in str
                                            select ch;

            foreach (char c in querySyntax)
            {
                Console.Write(c + " ");
            }
        }

        private static void SelectManyExample1()
        {
            List<string> nameList = new List<string>()
            {
                "Pranaya", "Kumar"
            };

            IEnumerable<char> methodSyntax = nameList.SelectMany(
                x => x);

            foreach (char c in methodSyntax)
            {
                Console.Write(c + " ");
            }
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
        public string Email { get; set; }
        public List<string> Programming { get; set; }
        public string Gender { get; set; }

        public static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student(){ID = 1, Name = "James", Email = "James@j.com", Programming = new List<string>() { "C#", "Jave", "C++"} },
                new Student(){ID = 2, Name = "Sam", Email = "Sara@j.com", Programming = new List<string>() { "WCF", "SQL Server", "C#" }},
                new Student(){ID = 3, Name = "Patrik", Email = "Patrik@j.com", Programming = new List<string>() { "MVC", "Jave", "LINQ"} },
                new Student(){ID = 4, Name = "Sara", Email = "Sara@j.com", Programming = new List<string>() { "ADO.NET", "C#", "LINQ" } }
            };
        }
    }
}