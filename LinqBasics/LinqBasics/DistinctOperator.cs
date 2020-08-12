using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class DistinctOperator
    {
        public static void OnValueType()
        {
            List<int> intCollection = new List<int>()
            {
                1,2,3,2,3,4,4,5,6,3,4,5
            };

            // use method syntax
            var MS = intCollection.Distinct();

            // use query syntax
            var QS = (from num in intCollection
                      select num).Distinct();

            foreach (var item in MS)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("===============Finsh============");
        }

        public static void OnStringType()
        {
            string[] namesArray = { "Priyanka", "HINA", "hina", "Anurag", "Anurag", "ABC", "abc" };

            var distinctNames = namesArray.Distinct();

            foreach (var name in distinctNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("===============Finsh============");
        }

        public static void OnStringCaseSensitive()
        {
            string[] namesArray = { "Priyanka", "HINA", "hina", "Anurag", "Anurag", "ABC", "abc" };

            var distinctNames = namesArray.Distinct(StringComparer.OrdinalIgnoreCase);
            
            foreach (var name in distinctNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("===============Finsh============");
        }

        public static void OnComplexType()
        {
            // use method syntax
            var MS = Student2.GetStudents()
                .Select(std => std.Name)
                .Distinct().ToList();

            // use query syntax
            var QS = (from std in Student2.GetStudents()
                      select std.Name)
                      .Distinct().ToList();

            foreach (var item in MS)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("===============Finsh============");
        }

        public static void OnObjDistinct()
        {
            // use method syntax
            var MS = Student.GetStudents()
                .Distinct().ToList();

            // use query syntax
            var QS = (from std in Student2.GetStudents()
                      select std)
                      .Distinct().ToList();

            foreach (var item in QS)
            {
                Console.WriteLine($"ID : {item.ID}, Name: {item.Name}");
            }
            Console.WriteLine("===============Finsh============");
        }

        public static void OnIEqualityComparer()
        {
            StudentComparer2 stdComparer = new StudentComparer2();

            // use method syntax
            var MS = Student2.GetStudents()
                .Distinct(stdComparer).ToList();

            // use query syntax
            var QS = (from std in Student2.GetStudents()
                      select std)
                      .Distinct(stdComparer).ToList();

            foreach (var item in QS)
            {
                Console.WriteLine($"ID : {item.ID} , Name : {item.Name} ");
            }

            Console.WriteLine("===============Finsh============");
        }

        public static void OnOverrideCompare()
        {
            var MS = Student2.GetStudents()
                .Distinct().ToList();

            var QS = (from std in Student2.GetStudents()
                      select std).Distinct().ToList();

            foreach (var item in MS)
            {
                Console.WriteLine($"ID : {item.ID} , Name : {item.Name} ");
            }

            Console.WriteLine("===============Finsh============");
        }
    }
}
