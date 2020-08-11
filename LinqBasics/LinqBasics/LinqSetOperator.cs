using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class LinqSetOperator
    {
        public static void LinqDistinctMethod()
        {
            List<int> intCollection = new List<int>()
            {
                1,2,3,2,3,4,4,5,6,3,4,5
            };

            // Using Method Syntax
            var MS = intCollection.Distinct();

            // QS
            var QS = (from num in intCollection
                      select num).Distinct();

            foreach (var item in MS)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n==============================");
        }
    
        public static void LinqDistinctMethod2()
        {
            string[] namesArray = { "Priyanka", "HINA", "hina", "Anurag", "Anurag", "ABC", "abc" };

            var distinctNames = namesArray.Distinct();

            foreach (var name in distinctNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\n==============================");
        }

        public static void LinqDistinctMethod3()
        {
            string[] namesArray = { "Priyanka", "HINA", "hina", "Anurag", "Anurag", "ABC", "abc" };

            var distinctNames = namesArray.Distinct(StringComparer.OrdinalIgnoreCase);

            foreach (var name in distinctNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("\n==============================");
        }

        public static void LinqDistinctWithComplexType()
        {
            // method syntax
            var MS = Student2.GetStudents()
                .Select(std => std.Name)
                .Distinct().ToList();

            // query syntax
            var QS = (from std in Student2.GetStudents()
                      select std.Name).Distinct().ToList();

            foreach (var item in MS)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n==============================");

        }

        public static void LinqDistinctWithComplexType2()
        {
            // method syntax
            var MS = Student2.GetStudents()
                .Distinct().ToList();

            // query syntax
            var QS = (from std in Student2.GetStudents()
                      select std).Distinct().ToList();

            foreach (var item in QS)
            {
                Console.WriteLine($"ID : {item.ID} , Name : {item.Name} ");
            }

            Console.WriteLine("\n==============================");
        }

        public static void Approach1()
        {

        }
    }
}
