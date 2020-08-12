using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class LinqExcept
    {
        //The LINQ Except Method in C# is used to return 
        //the elements which are present in the first data source 
        //but not in the second data source. 
        public static void Example1()
        {
            List<int> dataSource1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> dataSource2 = new List<int>() { 1, 3, 5, 8, 9, 10 };

            var MS = dataSource1.Except(dataSource2).ToList();

            var QS = (from num in dataSource1
                      select num).Except(dataSource2).ToList();

            foreach (var item in QS)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("===============Finish================");
        }

        public static void Example2()
        {
            string[] dataSource1 = { "India", "USA", "UK", "Canada", "Srilanka" };
            string[] dataSource2 = { "India", "uk", "Canada", "France", "Japan" };

            var MS = dataSource1.Except(dataSource2).ToList();

            var QS = (from country in dataSource1
                      select country)
                     .Except(dataSource2).ToList();
            foreach (var item in QS)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("===============Finish================");
        }

        public static void Example3()
        {
            string[] dataSource1 = { "India", "USA", "UK", "Canada", "Srilanka" };
            string[] dataSource2 = { "India", "uk", "Canada", "France", "Japan" };

            var MS = dataSource1.Except(dataSource2, StringComparer.OrdinalIgnoreCase).ToList();

            var QS = (from country in dataSource1
                      select country).Except(dataSource2, StringComparer.OrdinalIgnoreCase).ToList(); ;

            foreach (var item in MS)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("===============Finish================");
        }

        public static void Example4()
        {
            List<StudentExcept> AllStudents = new List<StudentExcept>()
            {
                new StudentExcept {ID = 101, Name = "Preety" },
                new StudentExcept {ID = 102, Name = "Sambit" },
                new StudentExcept {ID = 103, Name = "Hina"},
                new StudentExcept {ID = 104, Name = "Anurag"},
                new StudentExcept {ID = 105, Name = "Pranaya"},
                new StudentExcept {ID = 106, Name = "Santosh"},
            };
            List<StudentExcept> Class6Students = new List<StudentExcept>()
            {
                new StudentExcept {ID = 102, Name = "Sambit" },
                new StudentExcept {ID = 104, Name = "Anurag"},
                new StudentExcept {ID = 105, Name = "Pranaya"},
            };

            // use method syntax
            var MS = AllStudents.Select(x => x.Name).Except(Class6Students.Select(y => y.Name)).ToList();

            // use query syntax
            var QS = (from std in AllStudents
                      select std.Name).Except(Class6Students.Select(y => y.Name)).ToList();

            foreach (var name in MS)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("===============Finish================");
        }

        public static void Example5()
        {
            List<StudentExcept> AllStudents = new List<StudentExcept>()
            {
                new StudentExcept {ID = 101, Name = "Preety" },
                new StudentExcept {ID = 102, Name = "Sambit" },
                new StudentExcept {ID = 103, Name = "Hina"},
                new StudentExcept {ID = 104, Name = "Anurag"},
                new StudentExcept {ID = 105, Name = "Pranaya"},
                new StudentExcept {ID = 106, Name = "Santosh"},
            };
            List<StudentExcept> Class6Students = new List<StudentExcept>()
            {
                new StudentExcept {ID = 102, Name = "Sambit" },
                new StudentExcept {ID = 104, Name = "Anurag"},
                new StudentExcept {ID = 105, Name = "Pranaya"},
            };

            // use method syntax
            var MS = AllStudents.Except(Class6Students).ToList();

            // use query syntax
            var QS = (from std in AllStudents
                      select std).Except(Class6Students).ToList();

            foreach (var student in MS)
            {
                Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
            }
        }

        public static void AnonymousExample6()
        {
            List<StudentExcept> AllStudents = new List<StudentExcept>()
            {
                new StudentExcept {ID = 101, Name = "Preety" },
                new StudentExcept {ID = 102, Name = "Sambit" },
                new StudentExcept {ID = 103, Name = "Hina"},
                new StudentExcept {ID = 104, Name = "Anurag"},
                new StudentExcept {ID = 105, Name = "Pranaya"},
                new StudentExcept {ID = 106, Name = "Santosh"},
            };
            List<StudentExcept> Class6Students = new List<StudentExcept>()
            {
                new StudentExcept {ID = 102, Name = "Sambit" },
                new StudentExcept {ID = 104, Name = "Anurag"},
                new StudentExcept {ID = 105, Name = "Pranaya"},
            };

            // use method syntax
            var MS = AllStudents.Select(x => new {x.ID, x.Name})
                .Except(Class6Students.Select(x => new { x.ID, x.Name })).ToList();

            // use query syntax
            var QS = (from std in AllStudents
                      select new { std.ID, std.Name })
                      .Except(Class6Students.Select(x => new { x.ID, x.Name }))
                      .ToList();

            foreach (var student in QS)
            {
                Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
            }

            Console.WriteLine("===============Finish================");
        }

        public static void UsingComparer()
        {
            List<StudentExcept> AllStudents = new List<StudentExcept>()
            {
                new StudentExcept {ID = 101, Name = "Preety" },
                new StudentExcept {ID = 102, Name = "Sambit" },
                new StudentExcept {ID = 103, Name = "Hina"},
                new StudentExcept {ID = 104, Name = "Anurag"},
                new StudentExcept {ID = 105, Name = "Pranaya"},
                new StudentExcept {ID = 106, Name = "Santosh"},
            };
            List<StudentExcept> Class6Students = new List<StudentExcept>()
            {
                new StudentExcept {ID = 102, Name = "Sambit" },
                new StudentExcept {ID = 104, Name = "Anurag"},
                new StudentExcept {ID = 105, Name = "Pranaya"},
            };

            StudentComparer3 stdComparer = new StudentComparer3();

            // use method syntax
            var MS = AllStudents.Except(Class6Students, stdComparer).ToList();

            // use query syntax
            var QS = (from std in AllStudents
                      select std).Except(Class6Students, stdComparer).ToList();

            foreach (var student in MS)
            {
                Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
            }
        }
    }
}
