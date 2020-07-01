using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class OfTypeOperator
    {
        public static void ExampleOne()
        {
            Console.WriteLine("\nOfType Operator Using Method syntax in C#.NET:");

            List<object> dataSource = new List<object>()
           {
                "Tom", "Mary", 50, "Prince", "Jack", 10, 20, 30, 40, "James"
           };

           List<int> intData = dataSource.OfType<int>().ToList();

           foreach (int number in intData)
           {
               Console.Write(number + " ");
           }

           Console.WriteLine("\n==============================");
        }

        public static void ExampleTwo()
        {
            Console.WriteLine("is operator");
            List<object> dataSource = new List<object>()
            {
                "Tom", "Mary", 50, "Prince", "Jack", 10, 20, 30, 40, "James"
            };

            var stringData = (from name in dataSource
                              where name is string
                              select name).ToList();

            foreach (string name in stringData)
            {
                Console.Write(name + " ");
            }

            Console.WriteLine("\n==============================");
        }

        public static void ExampleThree()
        {
            Console.WriteLine("OfType and is Operator with a condition in C#.NET:\n");
            List<object> dataSource = new List<object>()
            {
                "Tom", "Mary", 50, "Prince", "Jack", 10, 20, 30, 40, "James"
            };

            // using method syntax
            var intData = dataSource.OfType<int>().Where(num => num > 30).ToList();
            foreach (int number in intData)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            // using Qyery Syntax
            var stringData = (from name in dataSource
                              where name is string && name.ToString().Length > 3
                              select name).ToList();

            foreach (string name in stringData)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine("\n==============================");
        }
    }
}
