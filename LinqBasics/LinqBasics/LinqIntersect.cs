using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class LinqIntersect
    {
        public static void Example1()
        {
            List<int> dataSource1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> dataSource2 = new List<int>() { 1, 3, 5, 8, 9, 10 };

            // use method syntax
            var MS = dataSource1.Intersect(dataSource2).ToList();

            // use query syntax
            var QS = (from num in dataSource1
                      select num)
                      .Intersect(dataSource2).ToList();

            foreach (var item in MS)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("================Finish============");
        }

        public static void Example2()
        {
            string[] dataSource1 = { "India", "USA", "UK", "Canada", "Srilanka" };
            string[] dataSource2 = { "India", "uk", "Canada", "France", "Japan" };

            // method syntax
            var MS = dataSource1.Intersect(dataSource2).ToList();

            // query syntax
            var QS = (from country in dataSource1
                      select country)
                      .Intersect(dataSource2).ToList();

            foreach (var item in QS)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("================Finish============");
        }

        public static void Example3()
        {
            string[] dataSource1 = { "India", "USA", "UK", "Canada", "Srilanka" };
            string[] dataSource2 = { "India", "uk", "Canada", "France", "Japan" };

            // method syntax
            var MS = dataSource1.Intersect(dataSource2, StringComparer.OrdinalIgnoreCase).ToList();

            // query syntax
            var QS = (from country in dataSource1
                      select country)
                      .Intersect(dataSource2, StringComparer.OrdinalIgnoreCase).ToList();

            foreach (var item in QS)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("================Finish============");
        }

        public static void ComplexExample1()
        {
            List<StudentExcept> StudentCollection1 = new List<StudentExcept>()
            {
                new StudentExcept {ID = 101, Name = "Preety" },
                new StudentExcept {ID = 102, Name = "Sambit" },
                new StudentExcept {ID = 105, Name = "Hina"},
                new StudentExcept {ID = 106, Name = "Anurag"},
            };

            List<StudentExcept> StudentCollection2 = new List<StudentExcept>()
            {
                new StudentExcept {ID = 105, Name = "Hina"},
                new StudentExcept {ID = 106, Name = "Anurag"},
                new StudentExcept {ID = 107, Name = "Pranaya"},
                new StudentExcept {ID = 108, Name = "Santosh"},
            };

            // use method syntax
            var MS = StudentCollection1.Select(x => x.Name)
                .Intersect(StudentCollection2.Select(y => y.Name)).ToList();

            // use query syntax
            var QS = (from std in StudentCollection1
                      select std.Name)
                      .Intersect(StudentCollection2.Select(y => y.Name)).ToList();

            foreach (var name in MS)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("================Finish============");
        }

        public static void ComplexExample2()
        {
            List<StudentExcept> StudentCollection1 = new List<StudentExcept>()
            {
                new StudentExcept {ID = 101, Name = "Preety" },
                new StudentExcept {ID = 102, Name = "Sambit" },
                new StudentExcept {ID = 105, Name = "Hina"},
                new StudentExcept {ID = 106, Name = "Anurag"},
            };

            List<StudentExcept> StudentCollection2 = new List<StudentExcept>()
            {
                new StudentExcept {ID = 105, Name = "Hina"},
                new StudentExcept {ID = 106, Name = "Anurag"},
                new StudentExcept {ID = 107, Name = "Pranaya"},
                new StudentExcept {ID = 108, Name = "Santosh"},
            };

            // use method syntax
            var MS = StudentCollection1.Intersect(StudentCollection2).ToList();

            // use query syntax
            var QS = (from std in StudentCollection1
                      select std).Intersect(StudentCollection2).ToList();

            foreach (var student in MS)
            {
                Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
            }

            Console.WriteLine("================Finish============");
        }

        public static void AnonymousComplexExample3()
        {
            List<StudentExcept> StudentCollection1 = new List<StudentExcept>()
            {
                new StudentExcept {ID = 101, Name = "Preety" },
                new StudentExcept {ID = 102, Name = "Sambit" },
                new StudentExcept {ID = 105, Name = "Hina"},
                new StudentExcept {ID = 106, Name = "Anurag"},
            };

            List<StudentExcept> StudentCollection2 = new List<StudentExcept>()
            {
                new StudentExcept {ID = 105, Name = "Hina"},
                new StudentExcept {ID = 106, Name = "Anurag"},
                new StudentExcept {ID = 107, Name = "Pranaya"},
                new StudentExcept {ID = 108, Name = "Santosh"},
            };

            // use method syntax
            var MS = StudentCollection1.Select(x => new { x.ID, x.Name })
                .Intersect(StudentCollection2.Select(x => new { x.ID, x.Name })).ToList();

            // use query syntax
            var QS = (from std in StudentCollection1
                      select new { std.ID, std.Name })
                      .Intersect(StudentCollection2.Select(x => new { x.ID, x.Name})).ToList();

            foreach (var student in MS)
            {
                Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
            }
            Console.WriteLine("================Finish============");
        }
    }
}
